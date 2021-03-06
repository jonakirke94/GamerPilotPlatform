﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using gamerpilotPlatform.Model.Lectures;
using System.Threading.Tasks;
using gamerpilotPlatform.Model.Lectures.Quiz;

namespace gamerpilotPlatform.Model
{
    public class CourseUser
    {
        public string UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }

        public string CourseId { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime EnrolledAt { get; set; }

        public Feedback Feedback { get; set; }
        public int? FeedbackId {get;set; }

        public ICollection<CompletedLectures> CompletedLectures { get; set; }

        public ICollection<QuizAttempt> QuizAttempts { get; set; }

        public CourseUser()
        {
            CompletedLectures = new List<CompletedLectures>();
            QuizAttempts = new List<QuizAttempt>();
        }
 

    }
}

