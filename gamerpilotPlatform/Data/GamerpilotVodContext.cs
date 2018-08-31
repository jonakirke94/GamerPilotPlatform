using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Model;
using Microsoft.EntityFrameworkCore;


namespace gamerpilotPlatform.Data
{
    public class GamerpilotVodContext : DbContext
    {

        public GamerpilotVodContext(DbContextOptions<GamerpilotVodContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<LearningGoal> LearningGoals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseIntroduction>().HasBaseType<Lecture>();
        }

    }
}
