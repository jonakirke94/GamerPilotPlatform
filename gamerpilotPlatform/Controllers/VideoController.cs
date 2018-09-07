using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerPilot.Video.Data;
using Microsoft.Extensions.Configuration;
using gamerpilotPlatform.Services;
using Microsoft.AspNetCore.Mvc;

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



        [HttpGet]
        public IEnumerable<int> Get()
        {
            var list = new List<int>
            {
                1,
                2,
                3,
                4
            };

            return list;
        }



        public string SQLConnectionString = "INSERT CONN STRING";

        //public async Task UseWithDatabaseAsync()
        //{
        //    //Add new video
        //    var videoByUpload = await GamerPilot.Video.Data.Helper
        //        .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
        //        .AddVideoAsync(
        //            instructor: "instructor",
        //            lesson: "lesson",
        //            videoName: "videoName",
        //            filePath: "filePath" //Or use File Stream overload
        //        );

        //    //Add new video
        //    var deleteVideo = await GamerPilot.Video.Data.Helper
        //        .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
        //        .DeleteVideoAsync(id: 1);

        //    //Get all videos
        //    var videos = await GamerPilot.Video.Data.Helper
        //        .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
        //        .GetVideosAsync();

        //    //Get video by Id
        //    var videoById = await GamerPilot.Video.Data.Helper
        //        .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
        //        .GetVideoAsync(id: 1);

        //    //Get videos by Instructor(s) - Async
        //    var videoByInstructorAsync = await GamerPilot.Video.Data.Helper
        //        .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
        //        .GetVideosByInstructorAsync("instructor");

        //    //Get videos by Lessons(s) - Async
        //    var videoByLessonAsync = await GamerPilot.Video.Data.Helper
        //        .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
        //        .GetVideosByLessonAsync("lesson");

        //    //Get videos by Lessons(s)
        //    var videoEmbedHTML = GamerPilot.Video.Data.Helper
        //        .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
        //        .GetVideoAsync(1).Result
        //        .GetEmbedHTML(width: 640, height: 360, playerUrl: "https://s3-eu-west-1.amazonaws.com/gamerpilot/player/player.html");
        //}
    }
}