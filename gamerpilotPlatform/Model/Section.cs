using gamerpilotPlatform.Model.Lectures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class Section
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }

        public Section()
        {
            Lectures = new List<Lecture>();
        }


    }
}

