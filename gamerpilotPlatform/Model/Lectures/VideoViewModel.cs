using GamerPilot.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model.Lectures
{
    public class VideoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InstructorName { get; set; }
        public string Url { get; set; }
    }
}

