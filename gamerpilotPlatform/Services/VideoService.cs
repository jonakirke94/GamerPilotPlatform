﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerPilot.Video.Data;
using gamerpilotPlatform.Model.Lectures;

namespace gamerpilotPlatform.Services
{
    public class VideoService : IVideoService
    {
        public AWSSettings options { get; } //set only via Secret Manager
        public readonly string connString;
        private readonly IConfiguration _configuration;
        private Helper _videoHelper { get; set; } //change to private later


        public VideoService(IOptions<AWSSettings> optionsAccessor, IConfiguration configuration)
        {
            options = optionsAccessor.Value;
            _configuration = configuration;
            connString = _configuration.GetConnectionString("VodContext");

            try
            {
                _videoHelper = Helper.Create(connString, options.AWSAccessKey, options.AWSSecretKey, options.AWSBucketName, options.AWSRegion);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<GamerPilot.Video.IVideo> AddVideo(int instructorId, int lectureId, string videoName, string filePath)
        {
                return await _videoHelper.AddVideoAsync(instructorId, lectureId, videoName, filePath);                
        }

        public IEnumerable<GamerPilot.Video.IVideo> GetVideos(int lectureId)
        {

            return _videoHelper.GetVideosByLesson(lectureId);
        }
    }
}

