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

            try
            {
                var userId = _tokenService.getClaimsId(authorization);

                var course = _context.Courses
                    .Include(x => x.Lectures)
                    .SingleOrDefault(x => x.UrlName == urlName);
                course.Sections = GetSectionFromLectureList(course.Lectures);
                course.EnrolledUsers = null; //avoid showing enrolled users to other people

                var courseUser = _context.CourseUsers
                    .Include(x => x.CompletedLectures)
                    .Include(x => x.Feedback)
                    .SingleOrDefault(x => x.Course.UrlName == urlName && x.UserId == userId);

                if (courseUser != null)
                {
                    courseUser.Course.EnrolledUsers = null; //avoid showing enrolled users to other people
                }

                return new ObjectResult(new
                {
                    enrolled = courseUser == null ? false : true,
                    course,
                    feedback = courseUser?.Feedback == null ? false : true,
                    completedLectures = courseUser?.CompletedLectures,
                });

            }
            catch (Exception ex)
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

        [HttpGet("[action]/{courseUrl}")]
        public IActionResult User([FromHeader]string authorization, string courseUrl)
        {
            var userId = _tokenService.getClaimsId(authorization);
            var course = _context.Courses.SingleOrDefault(x => x.UrlName == courseUrl);

            //check if user is enrolled
            var courseUser = _context.CourseUsers
                .Include(x => x.Feedback)                
                .SingleOrDefault(x => x.CourseId == course.Id && x.UserId == userId);
            var isCompleted = false;

            if (courseUser != null && courseUser.IsCompleted)
            {
                isCompleted = true;
            }
            return new ObjectResult(new
            {
                isEnrolled = courseUser == null ? false : true,
                isCompleted,
                feedback = courseUser?.Feedback == null ? false : true,

            });
   
        }

        [HttpGet("[action]/{courseUrl}")]
        [Authorize]
        public IActionResult HasFeedback([FromHeader]string authorization, string courseUrl)
        {
            var userId = _tokenService.getClaimsId(authorization);
            var courseUser = _context.CourseUsers
                .Include(x => x.Feedback)
                .SingleOrDefault(x => x.UserId == userId && x.Course.UrlName == courseUrl);

            return Ok(courseUser.Feedback != null);


        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult Feedback([FromHeader]string authorization, [FromBody]Feedback feedback)
        {
            try
            {
                var userId = _tokenService.getClaimsId(authorization);

                if (feedback == null || string.IsNullOrWhiteSpace(userId))
                {
                    return BadRequest();
                }

                var courseUser = _context.CourseUsers.SingleOrDefault(x => x.UserId == userId && x.Course.UrlName == feedback.CourseUrl);

                var userFeedback = new Feedback()
                {
                    DifferentFromYoutube = feedback.DifferentFromYoutube,
                    HowMuch = feedback.HowMuch,
                    LikelyToRecommend = feedback.LikelyToRecommend,
                    Rating = feedback.Rating,
                    WillingToPay = feedback.WillingToPay,
                    YoutubeResponse = feedback.YoutubeResponse
                };
                _context.Feedbacks.Add(userFeedback);
                _context.SaveChanges();

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

        private IEnumerable<Model.Section> GetSectionFromLectureList(IEnumerable<Lecture> lectures)
        {
            var sections = new List<Model.Section>();
            var welcome = new Model.Section()
            {
                Name = "Welcome",
                Order = 1,
            };
            var realLife = new Model.Section()
            {
                Name = "Real life perspective",
                Order = 2,
            };
            var game = new Model.Section()
            {
                Name = "Diving into CS:GO",
                Order = 3,
            };
            var quiz = new Model.Section()
            {
                Name = "Quiz",
                Order = 4,
            };
            var practice = new Model.Section()
            {
                Name = "Put it into practice",
                Order = 5,
            };
            var summary = new Model.Section()
            {
                Name = "Summary",
                Order = 6,
            };

            foreach (var lec in lectures)
            {
                switch (lec.Section)
                {
                    case Model.Lectures.Section.Welcome:
                        welcome.Lectures.Add(lec);
                        break;
                    case Model.Lectures.Section.RealLife:
                        realLife.Lectures.Add(lec);
                        break;
                    case Model.Lectures.Section.Quiz:
                        quiz.Lectures.Add(lec);
                        break;
                    case Model.Lectures.Section.Game:
                        game.Lectures.Add(lec);
                        break;
                    case Model.Lectures.Section.Practice:
                        practice.Lectures.Add(lec);
                        break;
                    case Model.Lectures.Section.Summary:
                        summary.Lectures.Add(lec);
                        break;

                }
            }

            sections.Add(welcome);
            sections.Add(realLife);
            sections.Add(quiz);
            sections.Add(game);
            sections.Add(practice);
            sections.Add(summary);

            return sections;
        }
    }

    
}