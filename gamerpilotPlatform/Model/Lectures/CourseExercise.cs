using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model.Lectures
{
    public class CourseExercise : Lecture
    {
        public string Description { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        public CourseExercise()
        {
            Exercises = new List<Exercise>();
        }
    }
}
