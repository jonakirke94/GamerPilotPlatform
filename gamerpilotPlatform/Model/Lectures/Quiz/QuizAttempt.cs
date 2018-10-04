using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model.Lectures.Quiz
{
    public class QuizAttempt
    {
        public int Id { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public DateTime SubmissionTime { get; set; }

        public QuizAttempt()
        {
            Answers = new List<Answer>();
        }
    }
}
