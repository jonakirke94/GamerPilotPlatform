using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class Course
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UrlName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public List<Lecture> Lectures { get; set; }

        public List<Instructor> Instructors { get; set; }

    }
}
