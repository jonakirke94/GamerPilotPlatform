using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public int LikelyToRecommend { get; set; }

        [Required]
        public string UniqueCourseOpinion { get; set; }

        [Required]
        public string WouldPayOpinion { get; set; }

        [NotMapped]
        public string CourseUrl { get; set; }
    }
}
