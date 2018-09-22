using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Model.Lectures;


namespace gamerpilotPlatform.Model
{
    public class Course
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UrlName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Boolean IsReleased { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<CourseUser> EnrolledUsers { get; set; }

        [NotMapped]
        public virtual IEnumerable<Section> Sections { get; set; }


        public Course()
        {
            Lectures = new List<Lecture>();
            EnrolledUsers = new List<CourseUser>();
            Sections = new List<Section>();
        }
    }
}



