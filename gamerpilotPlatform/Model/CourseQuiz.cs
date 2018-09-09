using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class CourseQuiz : Lecture
    {
        public ICollection<Question> Questions { get; set; }

        public CourseQuiz()
        {
            Questions = new List<Question>();
        }
    }
}
