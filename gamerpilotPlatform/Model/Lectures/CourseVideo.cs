using GamerPilot.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model.Lectures
{
    public class CourseVideo : Lecture
    {
        [NotMapped]
        public IEnumerable<VideoViewModel> Videos { get; set; }

        public CourseVideo()
        {
            Videos = new List<VideoViewModel>();
        }
    }
}


