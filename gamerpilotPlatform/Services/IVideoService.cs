using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerPilot.Video.Data;
using gamerpilotPlatform.Model.Lectures;

namespace gamerpilotPlatform.Services
{
    public interface IVideoService
    {
        IEnumerable<VideoViewModel> GetVideoViewModels(int lectureId);
        Task<GamerPilot.Video.IVideo> AddVideo(int instructorId, int lectureId, string videoName, string filePath);
    }
}


