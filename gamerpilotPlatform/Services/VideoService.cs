using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerPilot.Video.Data;

namespace gamerpilotPlatform.Services
{
    public class VideoService : IVideoService
    {
        public AWSSettings Options { get; } //set only via Secret Manager
        public readonly string ConnString;
        private readonly IConfiguration _configuration;
        private GamerPilot.Video.Data.Helper _videoHelper;


        public VideoService(IOptions<AWSSettings> optionsAccessor, IConfiguration configuration)
        {
            Options = optionsAccessor.Value;
            _configuration = configuration;
            ConnString = _configuration.GetConnectionString("VodContext");
            _videoHelper = Helper.Create(ConnString, Options.AWSAccessKey, Options.AWSSecretKey, Options.AWSBucketName, Options.AWSRegion);
        }

        public IEnumerable<GamerPilot.Video.IVideo> GetVideos()
        {
            var x = _videoHelper.GetVideos();
            return _videoHelper.GetVideos();
        }





    }
}
