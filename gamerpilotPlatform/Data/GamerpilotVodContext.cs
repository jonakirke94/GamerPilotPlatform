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
        public DbSet<Question> Questions { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Exercise> Exercises { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set inheritance base classes
            modelBuilder.Entity<CourseIntroduction>().HasBaseType<Lecture>();
            modelBuilder.Entity<CourseInfo>().HasBaseType<Lecture>();
            modelBuilder.Entity<CourseCase>().HasBaseType<Lecture>();
            modelBuilder.Entity<CourseQuiz>().HasBaseType<Lecture>();
            modelBuilder.Entity<CourseSummary>().HasBaseType<Lecture>();
            modelBuilder.Entity<CourseVideo>().HasBaseType<Lecture>();
            modelBuilder.Entity<CourseExercise>().HasBaseType<Lecture>();

        }

    }
}
