using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model.Lectures.Quiz;
using gamerpilotPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace gamerpilotPlatform.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private readonly GamerpilotVodContext _context;
        private readonly ILogger<QuizController> _log;
        private readonly ITokenService _tokenService;

        public QuizController(GamerpilotVodContext context, ILogger<QuizController> log, ITokenService tokenService)
        {
            _context = context;
            _log = log;
            _tokenService = tokenService;
        }

        [HttpPost("[action]")]
        [Authorize]
        public IActionResult Answer([FromHeader]string authorization, [FromBody]JObject body)
        {
            var choices = body.Value<String>("choices");
            var choiceArr = JsonConvert.DeserializeObject<String[]>(choices);
            var urlName = body.Value<String>("urlName");
            var userId = _tokenService.getClaimsId(authorization);

            if (String.IsNullOrEmpty(urlName))
            {
                return BadRequest();
            }
            else
            {
                var courseUser = _context.CourseUsers
                    .Include(x => x.QuizAttempts)
                    .SingleOrDefault(x => x.Course.UrlName == urlName && x.User.Id == userId);

                var attempt = new QuizAttempt();
                attempt.SubmissionTime = DateTime.Now;
                foreach (var stringId in choiceArr)
                {
                    var id = int.Parse(stringId);
                    var answer = new Answer()
                    {
                        UserChoiceId = id
                    };
                    _context.Answers.Add(answer);
                    _context.SaveChanges();
                    attempt.Answers.Add(answer);
                }
                courseUser.QuizAttempts.Add(attempt);

                _context.SaveChanges();
                _log.LogInformation($"Added quizattempt for for {userId}");
                return Ok();
            }
        }

        [HttpGet("[action]/{urlName}")]
        [Authorize]
        public IActionResult Attempts([FromHeader]string authorization, string urlName)
        {

            try
            {
                var userId = _tokenService.getClaimsId(authorization);


                var courseUser = _context.CourseUsers
                    .Include(x => x.QuizAttempts)
                        .ThenInclude(x => x.Answers)
                    .SingleOrDefault(x => x.Course.UrlName == urlName && x.UserId == userId);

                return Ok(courseUser.QuizAttempts);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }

   
}