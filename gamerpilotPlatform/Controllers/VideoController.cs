using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerPilot.Video.Data;
using Microsoft.Extensions.Configuration;
using gamerpilotPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using gamerpilotPlatform.Model;
using Microsoft.AspNetCore.Http;

namespace gamerpilotPlatform.Controllers
{

    [Route("api/[controller]")]
    public class VideoController : Controller
    {

        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }


        //public async Task<IActionResult> Post([FromBody]PostVideo video)
        //{
        //    try
        //    {
        //        await _videoService.AddVideo(video.InstructorId, video.LectureId, video.Name, video.FilePath);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError);

        //    }

        //}
    }
}