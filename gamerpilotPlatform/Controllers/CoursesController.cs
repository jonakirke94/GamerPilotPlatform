using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model;
using gamerpilotPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace gamerpilotPlatform.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly GamerpilotVodContext _context;
        private readonly IVideoService _videoService;
        private readonly ITokenService _tokenService;

        public CoursesController(GamerpilotVodContext context, IVideoService videoService, ITokenService tokenService)
        {
            _context = context;
            _videoService = videoService;
            _tokenService = tokenService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Course> courses = new List<Course>();
            //var vid = _videoService.GetVideos();

            try
            {
                courses = _context.Courses.ToList();
            }
            catch (Exception)
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

                if (String.IsNullOrEmpty(authorization))
                {
                    var userId = _tokenService.getClaimsId(authorization);
                    isEnrolledEntity = _context.CourseUsers.
                        Include(x => x.CompletedLectures)
                        .FirstOrDefault(x => x.Course.UrlName == urlName && x.UserId == userId);
                }

                course = _context.Courses
                       .Include(x => x.Instructors)
                       .Include(x => x.Lectures)
                       .SingleOrDefault(x => x.UrlName == urlName);

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
                        UserId = userId
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
                        lecture = _context.Lectures.OfType<CourseInfo>()
                        .SingleOrDefault(x => x.Id == id);
                        break;
                    case "CourseCase":
                        lecture = _context.Lectures.OfType<CourseCase>()
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
                        lecture = _context.Lectures.OfType<CourseVideo>()
                        .Include(x => x.Videos)
                        .SingleOrDefault(x => x.Id == id);
                        break;
                    default:
                        lecture = _context.Lectures.OfType<CourseInfo>()
                        .SingleOrDefault(x => x.Id == id);
                        break;
                }
            }
            catch (Exception)
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
    



            //Course course = null;

            //try
            //{
            //    course = _context.Courses
            //        .Include(x => x.Instructors)
            //        .Include(x => x.Lectures)
            //        .SingleOrDefault(x => x.UrlName == urlName);
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}


            //return new ObjectResult(new
            //{
            //    data = course
            //});
        }
    }
}