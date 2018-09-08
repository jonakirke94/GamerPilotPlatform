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

        public virtual ICollection<Lecture> Lectures { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }

        public virtual ICollection<CourseUser> EnrolledCourses { get; set; }


        public Course()
        {
            Lectures = new List<Lecture>();
            Instructors = new List<Instructor>();
            EnrolledCourses = new List<CourseUser>();
        }
    }
}


