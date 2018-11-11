using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Data;
using gamerpilotPlatform.Model;
using Microsoft.AspNetCore.Mvc;

namespace gamerpilotPlatform.Controllers
{
    [Route("api/[controller]")]
    public class GamerTestController : Controller
    {
        private readonly GamerpilotVodContext _context;

        public GamerTestController(GamerpilotVodContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TestQuestion> Get()
        {
            var questions = new List<TestQuestion>
            {
                // surgency-or-extraversion
                new TestQuestion
                {
                    Text = "I am the life of the party",
                    Category = "surgency-or-extraversion",
                    PlusKey = true
                },
                new TestQuestion
                {
                    Text = "I talk to a lot of different people at parties",
                    Category = "surgency-or-extraversion",
                    PlusKey = true
                },
                new TestQuestion
                {
                    Text = "I don't talk a lot",
                    Category = "surgency-or-extraversion",
                    PlusKey = false
                },
                new TestQuestion
                {
                    Text = "I keep in the background",
                    Category = "surgency-or-extraversion",
                    PlusKey = false
                },
                // agreeableness
                new TestQuestion
                {
                    Text = "I sympathize with others' feelings",
                    Category = "agreeableness",
                    PlusKey = true
                },
                new TestQuestion
                {
                    Text = "I feel others' emotions",
                    Category = "agreeableness",
                    PlusKey = true
                },
                new TestQuestion
                {
                    Text = "I am not really interested in others",
                    Category = "agreeableness",
                    PlusKey = false
                },
                new TestQuestion
                {
                    Text = "I am not interested in other people's problems",
                    Category = "agreeableness",
                    PlusKey = false
                },
                // conscientiousness
                new TestQuestion
                {
                    Text = "I get things done right away",
                    Category = "conscientiousness",
                    PlusKey = true
                },
                new TestQuestion
                {
                    Text = "I like order",
                    Category = "conscientiousness",
                    PlusKey = true
                },
                new TestQuestion
                {
                    Text = "I often forget to put things back in their proper place",
                    Category = "conscientiousness",
                    PlusKey = false
                },
                new TestQuestion
                {
                    Text = "I make a mess of things",
                    Category = "conscientiousness",
                    PlusKey = false
                },
                // intellect or imagination
                new TestQuestion
                {
                    Text = "I have a rich imagination",
                    Category = "intellect-or-imagination",
                    PlusKey = true
                },
                new TestQuestion
                {
                    Text = "I have difficulty understanding abstract ideas",
                    Category = "intellect-or-imagination",
                    PlusKey = false
                },
                new TestQuestion
                {
                    Text = "I am not interested in abstract ideas",
                    Category = "intellect-or-imagination",
                    PlusKey = false
                },
                new TestQuestion
                {
                    Text = "I do not have a good imagination",
                    Category = "intellect-or-imagination",
                    PlusKey = false
                },
            };

            Random rnd = new Random();
            //return shuffled array
            return questions.OrderBy(x => rnd.Next());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<TestQuestion> answers)
        {
            var scores = new List<TestScore>
            {
                new TestScore
                {
                    Score = GetCategoryScore(answers, "surgency-or-extraversion"),
                    Category = "surgency-or-extraversion"
                },
                 new TestScore
                {
                    Score = GetCategoryScore(answers, "agreeableness"),
                    Category = "agreeableness"
                },
                 new TestScore
                {
                    Score = GetCategoryScore(answers, "conscientiousness"),
                    Category = "conscientiousness"
                },
                new TestScore
                {
                    Score = GetCategoryScore(answers, "intellect-or-imagination"),
                    Category = "intellect-or-imagination"
                }
            };

            var highest = scores.OrderByDescending(o => o.Score).FirstOrDefault();
            var description = GetDescription(highest.Category);

            // save result to db 
            _context.TestResults.Add(new TestResults
            {
                DateCreated = DateTime.Now,
                GamerProfile = description,
            });
            await _context.SaveChangesAsync();

            return Ok(description);
        }

        private int GetWeightedValue(TestQuestion answer)
        {
            var res = answer.Value;

            if (!answer.PlusKey)
            {
                switch (answer.Value)
                {
                    case 1: res = 5;
                    break;
                    case 2: res = 4;
                    break;
                    case 3: res = 3;
                    break;
                    case 4: res = 2;
                    break;
                    case 5: res = 1;
                    break;
                }
            }

            return res;


        }

        private int GetCategoryScore(List<TestQuestion> answers, string category)
        {
            var filteredAnswers = answers.Where(x => x.Category == category);
            var score = 0;
            foreach (var answer in filteredAnswers)
            {
                score += GetWeightedValue(answer);
            }

            return score;
        }

        private GamerProfile GetDescription(string category)
        {
            GamerProfile profile = null;
            switch (category)
            {
                case "surgency-or-extraversion":
                    profile = _context.GamerProfiles.SingleOrDefault(x => x.Category == "Extraversion");
                    break;
                case "agreeableness":
                    profile = _context.GamerProfiles.SingleOrDefault(x => x.Category == "Agreeableness");
                    break;
                case "conscientiousness":
                    profile = _context.GamerProfiles.SingleOrDefault(x => x.Category == "Conscientiousness");
                    break;
                case "intellect-or-imagination":
                    profile = _context.GamerProfiles.SingleOrDefault(x => x.Category == "Openess");
                    break;
            }

        return profile;
        }



    }
}