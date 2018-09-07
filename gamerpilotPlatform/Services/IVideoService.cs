using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerPilot.Video.Data;

namespace gamerpilotPlatform.Services
{
    public interface IVideoService
    {
        IEnumerable<GamerPilot.Video.IVideo> GetVideos();     
    }
}

