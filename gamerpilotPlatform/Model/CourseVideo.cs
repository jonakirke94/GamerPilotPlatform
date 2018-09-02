using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class CourseVideo : Lecture
    {       
        public List<Video> Videos { get; set; }

        public CourseVideo()
        {
            Videos = new List<Video>();
        }
    }
}


