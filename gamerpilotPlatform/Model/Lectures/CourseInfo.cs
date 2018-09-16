using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model.Lectures
{
    public class CourseInfo : Lecture
    {
        public string Level { get; set; }
        public string CourseLength { get; set; }
        public string Language { get; set; }
        public string LifeSkill { get; set; }

        [NotMapped]
        public IEnumerable<InstructorViewModel> Instructors { get; set; }

        public CourseInfo()
        {
            Instructors = new List<InstructorViewModel>();
        }

    }
}
