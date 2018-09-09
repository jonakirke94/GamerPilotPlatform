using System;
using System.Collections.Generic;
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

        //producers fetched from course -> lectures -> instructors

    }
}
