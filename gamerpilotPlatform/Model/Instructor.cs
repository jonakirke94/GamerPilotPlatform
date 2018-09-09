using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class Instructor
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public Instructor()
        {
            Lectures = new List<Lecture>();
        }
    }
}
