﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class User
    {
        public string Id { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string RefreshToken { get; set; }

        public virtual ICollection<CourseUser> EnrolledUsers { get; set; }

        public User()
        {
            EnrolledUsers = new List<CourseUser>();
        }

    }
}
