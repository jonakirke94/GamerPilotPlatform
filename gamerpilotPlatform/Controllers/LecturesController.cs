using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model.Lectures;
using gamerpilotPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace gamerpilotPlatform.Controllers
{

    [Route("api/[controller]")]
    public class LecturesController : Controller
    {
        private readonly GamerpilotVodContext _context;
        private readonly ILogger<LecturesController> _log;
        private readonly ITokenService _tokenService;
        private readonly IVideoService _videoService;

        public LecturesController(GamerpilotVodContext context, ILogger<LecturesController> log, IVideoService videoService, ITokenService tokenService)
        {
            _context = context;
            _log = log;
            _tokenService = tokenService;
            _videoService = videoService;
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
                            .ThenInclude(y => y.Choices)
                        .SingleOrDefault(x => x.Id == id);
                        break;
                    case "CourseSummary":
                        lecture = _context.Lectures.OfType<CourseSummary>()
                        .SingleOrDefault(x => x.Id == id);
                        break;
                    case "CourseVideo":
                        var courseVid = _context.Lectures.OfType<CourseVideo>()
                        .SingleOrDefault(x => x.Id == id);
                        courseVid.Videos = GetVideoViewModels(id);
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

        private IEnumerable<VideoViewModel> GetVideoViewModels(int lectureId)
        {
            var viewVms = new List<VideoViewModel>();
            var videos = _videoService.GetVideos(lectureId);

            foreach (var vid in videos)
            {
                var instructor = _context.Instructors.SingleOrDefault(x => x.Id == vid.InstructorId);
                viewVms.Add(new VideoViewModel
                {                    
                    Id = vid.Id,
                    Name = vid.Name,
                    InstructorName = instructor.Name,
                    Url = vid.GetPlayerUrl(),
                });
            }
            return viewVms;
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult Complete([FromHeader]string authorization, [FromBody]JObject body)
        {
            try
            {
                var lectureId = body.Value<Int32>("id");
                var urlName = body.Value<String>("urlName");
                var isLastLecture = body.Value<Boolean>("isLastLecture");

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

                    // if the lecture is also the last mark the course as completed
                    if (isLastLecture)
                    {
                        courseUser.IsCompleted = true;
                    }

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
