using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GamerPilot.Video;
using gamerpilotPlatform.Model.Lectures;

namespace gamerpilotPlatform.Model
{
    public class Instructor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public ICollection<Lecture> Lectures { get; set; }

        [NotMapped]
        public ICollection<IVideo> Videos { get; set; }

        public Instructor()
        {
            Videos = new List<IVideo>();
            Lectures = new List<Lecture>();
        }
    }
}

