using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                course = _context.Courses.SingleOrDefault(x => x.Name == urlName);
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
}
}