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

        public List<Lecture> Lectures { get; set; }
    }
}
