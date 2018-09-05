using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamerPilot.Video.Data;
using Microsoft.Extensions.Configuration;

namespace gamerpilotPlatform.Controllers
{

    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private IConfiguration _configuration;
        private readonly string AWSAccessKey = "AKIAIPFLJO3U6ZQX3QUA";
        private readonly string AWSSecretKey = "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";
        private readonly string AWSBucketName = "gamerpilot";
        private readonly Amazon.RegionEndpoint AWSRegion = Amazon.RegionEndpoint.EUWest1;

        public VideoController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }



        [HttpGet("[action]")]
        public IEnumerable<int> Test()
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

        public async Task UseWithDatabaseAsync()
        {
            //Add new video
            var videoByUpload = await GamerPilot.Video.Data.Helper
                .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
                .AddVideoAsync(
                    instructor: "instructor",
                    lesson: "lesson",
                    videoName: "videoName",
                    filePath: "filePath" //Or use File Stream overload
                );

            //Add new video
            var deleteVideo = await GamerPilot.Video.Data.Helper
                .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
                .DeleteVideoAsync(id: 1);

            //Get all videos
            var videos = await GamerPilot.Video.Data.Helper
                .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
                .GetVideosAsync();

            //Get video by Id
            var videoById = await GamerPilot.Video.Data.Helper
                .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
                .GetVideoAsync(id: 1);

            //Get videos by Instructor(s) - Async
            var videoByInstructorAsync = await GamerPilot.Video.Data.Helper
                .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
                .GetVideosByInstructorAsync("instructor");

            //Get videos by Lessons(s) - Async
            var videoByLessonAsync = await GamerPilot.Video.Data.Helper
                .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
                .GetVideosByLessonAsync("lesson");

            //Get videos by Lessons(s)
            var videoEmbedHTML = GamerPilot.Video.Data.Helper
                .Create(SQLConnectionString, AWSAccessKey, AWSSecretKey, AWSBucketName, AWSRegion)
                .GetVideoAsync(1).Result
                .GetEmbedHTML(width: 640, height: 360, playerUrl: "https://s3-eu-west-1.amazonaws.com/gamerpilot/player/player.html");
        }
    }
}