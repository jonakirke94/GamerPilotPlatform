using gamerpilotPlatform.Model.Lectures.Quiz;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model.Lectures
{
    public class Question
    {
        public string Id { get; set; }

        public string Difficulty { get; set; }

        public string QuestionText { get; set; }

        public List<Choice> Choices { get; set; }

        public Question()
        {
            Choices = new List<Choice>();
        }
    }
}
