using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model;
using gamerpilotPlatform.Model.Lectures;
using gamerpilotPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace gamerpilotPlatform.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly GamerpilotVodContext _context;
        private readonly IVideoService _videoService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<CoursesController> _log;

        public CoursesController(GamerpilotVodContext context, IVideoService videoService, ITokenService tokenService, ILogger<CoursesController> log)
        {
            _context = context;
            _videoService = videoService;
            _tokenService = tokenService;
            _log = log;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Course> courses = new List<Course>();

            try
            {
                courses = _context.Courses.ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            return new ObjectResult(new
            {
                data = courses
            });
        }

        [HttpGet("{urlName}")]
        public IActionResult Get([FromHeader]string authorization, string urlName)
        {
            Course course = null;

            try
            {
                CourseUser isEnrolledEntity = null;
                var userId = _tokenService.getClaimsId(authorization);

                course = _context.Courses
                    .Include(x => x.Lectures)
                    .SingleOrDefault(x => x.UrlName == urlName);
            
              
                isEnrolledEntity = _context.CourseUsers
                    .Include(x => x.CompletedLectures)
                    .SingleOrDefault(x => x.Course.UrlName == urlName && x.UserId == userId);
                
                if (isEnrolledEntity == null)
                {
                    // if not enrolled just return the course
                    return new ObjectResult(new
                    {
                        enrolled = isEnrolledEntity == null ? false : true,
                        course,
                    });
                }
                else
                {
                    // if enrolled return the course with completed lectures
                    return new ObjectResult(new
                    {
                        enrolled = isEnrolledEntity == null ? false : true,
                        course,
                        completedLectures = isEnrolledEntity.CompletedLectures
                    });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
         
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult Enroll([FromHeader]string authorization, [FromBody] Course course)
        {
            try
            {
                var courseId = _context.Courses.SingleOrDefault(x => x.UrlName == course.UrlName).Id;
                var userId = _tokenService.getClaimsId(authorization);

                if (!String.IsNullOrEmpty(course.UrlName) && !String.IsNullOrEmpty(courseId))
                {
                    _context.CourseUsers.Add(new CourseUser
                    {
                        CourseId = courseId,
                        UserId = userId,
                        EnrolledAt = DateTime.Now
                    });
                    _context.SaveChanges();

                    return Ok();
            }
                else
                {
                return BadRequest();
            }
        }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //GET course/communication-in-csgo/lecture/1
        [HttpGet("{name}/[action]/{id}")]
        [Authorize]
        public IActionResult Lecture([FromHeader]string authorization, string name, int id)
        {
            object lecture = null;

            try
            {
                var courseExists = _context.Courses.Any(x => x.UrlName == name && x.Lectures.Any(y => y.Id == id));

                if (!courseExists)
                {
                    return BadRequest();
                }

                var userId = _tokenService.getClaimsId(authorization);
                var isEnrolled = _context.CourseUsers.Any(x => x.Course.UrlName == name && x.UserId == userId);

                if (!isEnrolled)
                {
                    return BadRequest("Not enrolled");
                }

                var type = _context.Lectures.SingleOrDefault(x => x.Id == id).GetType().Name;

                switch (type)
                {
                    case "CourseIntroduction":
                        lecture = _context.Lectures.OfType<CourseIntroduction>()
                        .Include(x => x.LearningGoals)
                        .SingleOrDefault(x => x.Id == id);
                        break;
                    case "CourseInfo":
                        var courseInfo = _context.Lectures.OfType<CourseInfo>()
                        .SingleOrDefault(x => x.Id == id);
                        courseInfo.Instructors = GetCourseInstructors(name);
                        lecture = courseInfo;
                        break;
                    case "CourseCase":
                        lecture = _context.Lectures.OfType<CourseCase>()
                         .Include(x => x.Sections)
                         .SingleOrDefault(x => x.Id == id);
                        break;
                    case "CourseExercise":
                        lecture = _context.Lectures.OfType<CourseExercise>()
                        .Include(x => x.Exercises)
                        .SingleOrDefault(x => x.Id == id);
                        break;
                    case "CourseQuiz":
                        lecture = _context.Lectures.OfType<CourseQuiz>()
                        .Include(x => x.Questions)
                        .SingleOrDefault(x => x.Id == id);
                        break;
                    case "CourseSummary":
                        lecture = _context.Lectures.OfType<CourseSummary>()
                        .SingleOrDefault(x => x.Id == id);
                        break;
                    case "CourseVideo":
                        var courseVid = _context.Lectures.OfType<CourseVideo>()
                        .SingleOrDefault(x => x.Id == id);
                        courseVid.Videos = _videoService.GetVideoViewModels(id);
                        lecture = courseVid;                       
                        break;
                    default:
                        lecture = _context.Lectures.OfType<CourseInfo>()
                        .SingleOrDefault(x => x.Id == id);
                        break;
                }
            }
            catch (Exception ex)
             {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return new ObjectResult(new
            {
                data = lecture
            });
        }



        [HttpGet("[action]/{courseUrl}")]
        public IActionResult User([FromHeader]string authorization, string courseUrl)
        {
            var userId = _tokenService.getClaimsId(authorization);
            var course = _context.Courses.SingleOrDefault(x => x.UrlName == courseUrl);

            //check if user is enrolled
            var isEnrolled = _context.CourseUsers.Any(x => x.CourseId == course.Id && x.UserId == userId);

                return new ObjectResult(new
                {
                    data = isEnrolled,
                });
   
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult Feedback([FromHeader]string authorization, [FromBody]JObject body)
        {
            try
            {
                var urlName = body.Value<String>("urlName");
                var feedback = body.Value<String>("feedback");
                var userId = _tokenService.getClaimsId(authorization);

                if (string.IsNullOrWhiteSpace(urlName) || string.IsNullOrWhiteSpace(feedback) || string.IsNullOrWhiteSpace(userId)) {
                    return BadRequest();
                }

                var courseUser = _context.CourseUsers.SingleOrDefault(x => x.UserId == userId && x.Course.UrlName == urlName);
                courseUser.Feedback = feedback;
                _context.SaveChanges();
                _log.LogInformation($"Saved feedback for {userId}");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult Complete([FromHeader]string authorization, [FromBody]JObject body)
        {          
            try
            {
                var lectureId = body.Value<Int32>("id");
                var urlName = body.Value<String>("urlName");

                var userId = _tokenService.getClaimsId(authorization);

                if (!String.IsNullOrEmpty(urlName) && lectureId > 0) 
                {
                    var courseUser = _context.CourseUsers
                        .Include(x => x.CompletedLectures)
                        .Include(x => x.User)
                        .Include(x => x.Course)
                        .SingleOrDefault(x => x.Course.UrlName == urlName && x.User.Id == userId);

                    // save lectureId to completeLecture table
                    var completedLecture = new CompletedLectures { LectureId = lectureId };
                    _context.CompletedLectures.Add(completedLecture);
                    _context.SaveChanges();

                    // add table to users list of completed courses;
                    courseUser.CompletedLectures.Add(completedLecture);
                    _context.SaveChanges();
                    _log.LogInformation($"User {userId} completed lecture {lectureId}");


                    var newCompletedLectures = _context.CourseUsers
                        .Include(x => x.CompletedLectures)
                        .Include(x => x.User)
                        .Include(x => x.Course)
                        .SingleOrDefault(x => x.Course.UrlName == urlName && x.User.Id == userId);

                    return new ObjectResult(new
                    {
                        data = newCompletedLectures.CompletedLectures,
                    });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private IEnumerable<InstructorViewModel> GetCourseInstructors(string name)
        {
            var course = _context.Courses
                .Include(x => x.Lectures)
                .ThenInclude(y => y.Instructor)
                .SingleOrDefault(x => x.UrlName == name);

            var resultList = new List<InstructorViewModel>();

            foreach (var lecture in course.Lectures)
            {
                if (lecture.Instructor != null)
                {
                    resultList.Add(new InstructorViewModel
                    {
                        Id = lecture.Instructor.Id,
                        Name = lecture.Instructor.Name
                    });
                }
            }

            return resultList;
        }
    }

    
}