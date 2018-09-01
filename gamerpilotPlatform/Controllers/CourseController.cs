using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace gamerpilotPlatform.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly GamerpilotVodContext _context;

        public CourseController(GamerpilotVodContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll(string name)
        {
            List<Course> courses = new List<Course>();

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

        [HttpGet("[action]/{urlName}")]
        public async Task<IActionResult> GetCourse(string urlName)
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
        public async Task<IActionResult> GetLecture(int id)
        {
            object lecture = null;

            try
            {
                var type = _context.Lectures.SingleOrDefault(x => x.Id == id).GetType().Name;

                if (type.Equals("CourseIntroduction"))
                {
                    lecture = _context.Lectures.OfType<CourseIntroduction>().Include(x => x.LearningGoals)
                    .SingleOrDefault(x => x.Id == id);
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