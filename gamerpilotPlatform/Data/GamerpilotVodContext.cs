using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Model;
using gamerpilotPlatform.Model.Lectures;

using Microsoft.EntityFrameworkCore;


namespace gamerpilotPlatform.Data
{
    public class GamerpilotVodContext : DbContext
    {

        public GamerpilotVodContext(DbContextOptions<GamerpilotVodContext> options)
       : base(options)
        {
            //Database.SetCommandTimeout(150000);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<LearningGoal> LearningGoals { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<CompletedLectures> CompletedLectures { get; set; }
        public DbSet<CaseSection> CaseSections { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }



        // many to many with customized join table
        /* https://stackoverflow.com/questions/7050404/create-code-first-many-to-many-with-additional-fields-in-association-table */

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

            // define composite primary key for joint table
            modelBuilder.Entity<CourseUser>().HasKey(t => new {
                t.UserId,
                t.CourseId
            });

            modelBuilder.Entity<CourseUser>()
            .HasOne(f => f.Feedback);
        

        //modelBuilder.Entity<GamerPilot.Video.IVideo>()
        //.HasMany(g => g.)
        //.WithOne(c => c.cou)
    }

    }
}
