using gamerpilotPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Data
{
    public static class SeedData
    {
        public static void Initialize(GamerpilotVodContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any users.
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                new User
                {
                    Email = "Test@Test.dk",
                    Username = "TestUser",
                    Password = "AQAAAAEAACcQAAAAEBEbjTr4E7rEPlOgmMZArDU1IHpxlvwk7faTxwJ2TXHfR1C8FpB/6JkzRTVnzzRdKg=="
                },
                   new User
                   {
                       Email = "Dum@Dum.dk",
                       Username = "DumUser",
                       Password = "AQAAAAEAACcQAAAAEBEbjTr4E7rEPlOgmMZArDU1IHpxlvwk7faTxwJ2TXHfR1C8FpB/6JkzRTVnzzRdKg=="
                   }

                );
                context.SaveChanges();

            }

            var instructor1 = new Instructor()
            {
                Name = "Anne Fiskali",
            };
            var instructo2 = new Instructor()
            {
                Name = "Frederik Røj",
            };

            context.Instructors.AddRange();


            var learningGoal1 = new LearningGoal() { Goal = "JUST A LEARNING GOAL" };
            var learningGoal2 = new LearningGoal() { Goal = "JUST A LEARNING GOAL2" };
            context.LearningGoals.AddRange(learningGoal1, learningGoal2);      
        
            context.SaveChanges();
            


            var lecture1 = new CourseIntroduction()
            {
                Order = 1,
                Section = Section.Welcome,
                LectureType = LectureType.CourseIntroduction,
                Description = "blbalbalb",
                
            };
            lecture1.LearningGoals.Add(learningGoal1);
            lecture1.LearningGoals.Add(learningGoal2);

            context.Lectures.Add(lecture1);

            context.SaveChanges();


            if (!context.Courses.Any())
            {
                var course1 = new Course
                {
                    Name = "Communication in CS:GO",
                    UrlName = "communication-in-csgo",
                    Description = "This course is about communication in CS:GO..",
                    ImageUrl = "https://picsum.photos/600/600?random",
                    Language = "English",
                    CourseLength = "35",
                    Level = "Beginner/Intermediate",
                    LifeSkill = "Communication"

                };
                course1.Lectures.Add(lecture1);
                context.Courses.Add(course1);

                context.Courses.AddRange(
                 
                    new Course
                    {
                        Name = "Strategy in CS:GO",
                        UrlName = "strategy-in-csgo",
                        Description = "This course is about strategy in CS:GO..",
                        ImageUrl = "https://picsum.photos/600/600?random",
                        Language = "English",
                        CourseLength = "35",
                        Level = "Beginner/Intermediate",
                        LifeSkill = "Communication"
                    },
                    new Course
                    {
                        Name = "Strategy1 in CS:GO",
                        UrlName = "strategy-in-csgo1",
                        Description = "This course is about strategy in CS:GO..",
                        ImageUrl = "https://picsum.photos/600/600?random",
                        Language = "English",
                        CourseLength = "35",
                        Level = "Beginner/Intermediate",
                        LifeSkill = "Communication"
                    },
                    new Course
                    {
                        Name = "Strategy in CS:GO2",
                        UrlName = "strategy-in-csgo2",
                        Description = "This course is about strategy in CS:GO..",
                        ImageUrl = "https://picsum.photos/600/600?random",
                        Language = "English",
                        CourseLength = "35",
                        Level = "Beginner/Intermediate",
                        LifeSkill = "Communication"
                    }
                );
                context.SaveChanges();
            }

            






        }
    }
}
