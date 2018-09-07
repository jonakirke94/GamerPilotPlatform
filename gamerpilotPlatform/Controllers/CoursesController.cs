using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model;
using gamerpilotPlatform.Services;
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

        public CoursesController(GamerpilotVodContext context, IVideoService videoService)
        {
            _context = context;
            _videoService = videoService;
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
        public IActionResult Get(string urlName)
        {
            Course course = null;

            try
            {
                course = _context.Courses
                    .Include(x => x.Instructors)
                    .Include(x => x.Lectures)
                    .SingleOrDefault(x => x.UrlName == urlName);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            return new ObjectResult(new
            {
                data = course
            });
        }

        [HttpGet("[action]/{id}")]
        public IActionResult Lecture(int id)
        {
            object lecture = null;

            try
            {
                var type = _context.Lectures.SingleOrDefault(x => x.Id == id).GetType().Name;

                switch (type)
                {
                    case "CourseIntroduction":
                        lecture = _context.Lectures.OfType<CourseIntroduction>().Include(x => x.LearningGoals)
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
    }
}