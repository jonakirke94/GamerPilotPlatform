﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class CourseUser
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string CourseId { get; set; }
        public virtual Course Course { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime EnrolledAt { get; set; }

        public ICollection<CompletedLectures> CompletedLectures { get; set; }

        public CourseUser()
        {
            CompletedLectures = new List<CompletedLectures>();
        }
 

    }
}
