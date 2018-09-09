using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model.Lectures
{
    public class CourseCase : Lecture
    {
        public string Description { get; set; }
        public ICollection<CaseSection> Sections { get; set; }

        public CourseCase()
        {
            Sections = new List<CaseSection>();
        }


    }
}
