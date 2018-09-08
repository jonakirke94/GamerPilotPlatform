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
                    Email = "test@test.dk",
                    Username = "TestUser",
                    Password = "AQAAAAEAACcQAAAAENoRYO3DXwVRVZ2JE9/kX+WCIQGGGZDmT9ERFDYTgbMpel4xEPWd6AxuCE/7nDOS/w=="
                });
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


            // COURSE INFO
            var CourseInfo = new CourseInfo()
            {
                CourseLength = "36min",
                Language = "English",
                LifeSkill = "Communication",
                Name = "Course Info",
                Level = "Beginner/Intermediate",
                Order = 1,
                LectureType = LectureType.Info,
                Section = Section.Welcome,
            };

            // COURSE INTRODUCTION
            var CourseIntroduction = new CourseIntroduction()
            {
                Order = 2,
                Name = "Course Introduction",
                Section = Section.Welcome,
                LectureType = LectureType.CourseIntroduction,
                Description = "blbalbalb",
                
                
            };
            var learningGoal1 = new LearningGoal() { Goal = "JUST A LEARNING GOAL" };
            var learningGoal2 = new LearningGoal() { Goal = "JUST A LEARNING GOAL2" };
            context.LearningGoals.AddRange(learningGoal1, learningGoal2);
            context.SaveChanges();

            CourseIntroduction.LearningGoals.Add(learningGoal1);
            CourseIntroduction.LearningGoals.Add(learningGoal2);

            // REAL LIFE PERSPECTIVE
            var video1 = new Video()
            {
                Title = "Video 1",
                VideoUrl = "https://www.youtube.com/watch?v=nZXOiv1IHNM"
            };

            context.Videos.Add(video1);
            context.SaveChanges();

            var RealLifePersp = new CourseVideo()
            {
                Name = "A look into communication from a psychologist",
                Order = 3,
                Section = Section.RealLife,
                LectureType = LectureType.Video
            };
            RealLifePersp.Videos.Add(video1);

            // CASE
            var courseCase = new CourseCase()
            {
                Name = "Communication ingame & in real life situations",
                Order = 4,
                Section = Section.RealLife,
                LectureType = LectureType.Case,
                Description = "BLBALBAL CASE!"
            };

            // QUIZ

            var question1 = new Question()
            {
                Text = "This is question1",
                Answer = "this is answer1",
                Difficulty = "easy",
            };
            var question2 = new Question()
            {
                Text = "This is question2",
                Answer = "this is answer2",
                Difficulty = "hard",
            };
            context.Questions.AddRange(question1, question2);
            context.SaveChanges();

            var courseQuiz = new CourseQuiz()
            {
                Name = "Quiz",
                Order = 5,
                Section = Section.Quiz,
                LectureType = LectureType.Quiz
            };
            courseQuiz.Questions.Add(question1);
            courseQuiz.Questions.Add(question2);

            // PRO CONTENT

            var video2 = new Video()
            {
                Title = "Video 2",
                VideoUrl = "https://www.youtube.com/watch?v=qvvLzd8SA5w",
            };
            var video3 = new Video()
            {
                Title = "Video 3",
                VideoUrl = "https://www.youtube.com/watch?v=O7r5lmYzwrk",
            };
            context.Videos.Add(video2);
            context.Videos.Add(video3);
            context.SaveChanges();

            var proContent = new CourseVideo()
            {
                Name = "Pro CS:GO content",
                Order = 6,
                Section = Section.Game,
                LectureType = LectureType.Video
            };
            proContent.Videos.Add(video2);
            proContent.Videos.Add(video3);

            // EXERCISES
            var exercise1 = new Exercise()
            {
                Description = "THIS IS EXERCISE 1"
            };
            var exercise2 = new Exercise()
            {
                Description = "THIS IS EXERCISE 2"
            };
            context.Exercises.Add(exercise1);
            context.Exercises.Add(exercise2);
            context.SaveChanges();

            var exercises = new CourseExercise()
            {
                Name = "Exercises",
                Order = 7,
                Section = Section.Practice,
                LectureType = LectureType.Practice,
                Description = "These are exercises in communication",
            };
            exercises.Exercises.Add(exercise1);
            exercises.Exercises.Add(exercise2);

            // SUMMARY
            var summary = new CourseSummary()
            {
                Name = "This is summary",
                Section = Section.Summary,
                Order = 8,
                LectureType = LectureType.Summary,
                Summary = "This will wraup up the..........",
            };


            context.Lectures.Add(CourseInfo);
            context.Lectures.Add(CourseIntroduction);
            context.Lectures.Add(RealLifePersp);
            context.Lectures.Add(courseCase);
            context.Lectures.Add(courseQuiz);
            context.Lectures.Add(proContent);
            context.Lectures.Add(exercises);
            context.Lectures.Add(summary);

            context.SaveChanges();


            if (!context.Courses.Any())
            {
                var course1 = new Course
                {
                    Name = "Communication in CS:GO",
                    UrlName = "communication-in-csgo",
                    Description = "This course is about communication in CS:GO..",
                    ImageUrl = "https://picsum.photos/600/600?random",
                };
                course1.Lectures.Add(CourseInfo);
                course1.Lectures.Add(CourseIntroduction);
                course1.Lectures.Add(RealLifePersp);
                course1.Lectures.Add(courseCase);
                course1.Lectures.Add(courseQuiz);
                course1.Lectures.Add(proContent);
                course1.Lectures.Add(exercises);
                course1.Lectures.Add(summary);

                context.Courses.Add(course1);

                context.Courses.AddRange(
                 
                    new Course
                    {
                        Name = "Strategy in CS:GO",
                        UrlName = "strategy-in-csgo",
                        Description = "This course is about strategy in CS:GO..",
                        ImageUrl = "https://picsum.photos/600/600?random",
                    },
                    new Course
                    {
                        Name = "Strategy1 in CS:GO",
                        UrlName = "strategy-in-csgo1",
                        Description = "This course is about strategy in CS:GO..",
                        ImageUrl = "https://picsum.photos/600/600?random",
                    },
                    new Course
                    {
                        Name = "Strategy in CS:GO2",
                        UrlName = "strategy-in-csgo2",
                        Description = "This course is about strategy in CS:GO..",
                        ImageUrl = "https://picsum.photos/600/600?random",
                    }
                );
                context.SaveChanges();
            }

            






        }
    }
}
