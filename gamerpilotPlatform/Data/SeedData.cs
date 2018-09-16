using gamerpilotPlatform.Model.Lectures;
using gamerpilotPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Services;

namespace gamerpilotPlatform.Data
{
    public static class SeedData
    {
        public static void Initialize(GamerpilotVodContext context, IVideoService videoService)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                try
                {
                    Seed(context, videoService).Wait();
                }
                catch (Exception ex)
                {

                    throw;
                }
               
            } 


          
        }

        public static async Task Seed(GamerpilotVodContext context, IVideoService videoService)
        {

            /*************************************************/
            /********** ADD USERS **********************/
            /*************************************************/
            context.Users.AddRange(
           new User
           {
               Email = "test@test.dk",
               Username = "TestUser",
               Password = "AQAAAAEAACcQAAAAENoRYO3DXwVRVZ2JE9/kX+WCIQGGGZDmT9ERFDYTgbMpel4xEPWd6AxuCE/7nDOS/w=="
           });
            context.SaveChanges();



            /*************************************************/
            /********** ADD INSTRUCTORS **********************/
            /*************************************************/
            var instructor1 = new Instructor()
            {
                Name = "Anne Fiskali",
            };
            var instructor2 = new Instructor()
            {
                Name = "Frederik Røj",
            };
            context.Instructors.AddRange(instructor1, instructor2);
            context.SaveChanges();

            /*************************************************/
            /********** COURSE INFO *** **********************/
            /*************************************************/
            var infoEntity = new CourseInfo()
            {
                CourseLength = "36min",
                Language = "English",
                LifeSkill = "Communication",
                Name = "Course Info",
                Level = "Beginner/Intermediate",
                LectureType = LectureType.Info,
                Section = Section.Welcome,
                DisplayOrder = 1,
            };

            /*************************************************/
            /********** COURSE INTRODUCTION ******************/
            /*************************************************/
            var introductionEntity = new CourseIntroduction()
            {
                Name = "Course Introduction",
                Section = Section.Welcome,
                LectureType = LectureType.CourseIntroduction,
                DisplayOrder = 2,
                Description = "In modern workplaces and on good CS:GO teams people are looking for graduates and players that are not only proficient in content, but also in soft skills. One of these skills is communication. Communication skills can be developed through both cooperative learning and direct" +
              " instruction, but highest increases are linked with cooperative settings. CS:GO is a great place to do this. \n \n You can communicate for a variety of purposes and audiences and it takes great awareness to know when to do what.In this course we primarily focus on communication in a context where the purpose is to convey a message in a cooperative situation where information needs to be communicated. " +
              "Mastering communication takes a long time, but by being aware and applying the knowledge you learn in this course you have already taken a big step. Practicing communication in CS: GO can be discouraging at times if your teammates do not put in the same effort as you - Don't worry!" +
              " As long as you do your part it will be reflected in your results in the long run! \n \n When you have finished this course you will be able to: ",


            };
            var learningGoal1 = new LearningGoal()
            {
                Goal = "Have knowledge of why communication is important"
            };
            var learningGoal2 = new LearningGoal()
            {
                Goal = "Be able to differentiate good and bad communication"
            };
            var learningGoal3 = new LearningGoal()
            {
                Goal = "Understand the connection between communication in real life and ingame"
            };
            var learningGoal4 = new LearningGoal()
            {
                Goal = "Know concrete methods to practice your communication"
            };
            context.LearningGoals.AddRange(learningGoal1, learningGoal2, learningGoal3, learningGoal4);
            context.SaveChanges();

            introductionEntity.LearningGoals.Add(learningGoal1);
            introductionEntity.LearningGoals.Add(learningGoal2);
            introductionEntity.LearningGoals.Add(learningGoal3);
            introductionEntity.LearningGoals.Add(learningGoal4);

            /*************************************************/
            /********** REAL LIFE PERSPECTIVE*****************/
            /*************************************************/
            var RealLifeLecture = new CourseVideo()
            {
                Name = "A psychologist's view",
                Section = Section.RealLife,
                LectureType = LectureType.Video,
                DisplayOrder = 3,
                Instructor = instructor1,
                InstructorId = instructor1.Id
            };
            context.Lectures.Add(RealLifeLecture);
            context.SaveChanges();

            /*************************************************/
            /********** VIDEOS *******************************/
            /*************************************************/
            await videoService.AddVideo(instructor1.Id, RealLifeLecture.Id, "Into the psychology", "C:\\Users\\inter\\Desktop\\AWS_Videos\\teori-erhvervsliv.MP4");

            /*************************************************/
            /********** CASE *********************************/
            /*************************************************/
            var caseEntity = new CourseCase()
            {
                Name = "A communication case",
                Section = Section.RealLife,
                LectureType = LectureType.Case,
                DisplayOrder = 4,
                Description = "Effective communication is a vital tool for any person in the modern world. Your ability to communicate your points across can be the difference between success or failure just like it can determine the outcome of a cs:go round. " +
              "Success in any conversation is likely to be achieved through both parties listening to and understanding each other.Considering circumstances surrounding your communications such as the situational and cultural context are crucial and often reveal who’s an efficient communicator and who’s not. " +
              "Let’s take a look at some of the key communication skills that make for a solid communication toolset in the context of a cs:go game and at a workplace"
            };
            var section1 = new CaseSection()
            {

                Title = "Using positive language",
                Body = "You are more likely to achieve positive outcomes when you use positive, rather than negative, language. This may seem like a no brainer but nevertheless countless people convey messages through anger and frustration which never has the same effect. Without doubt you have experienced a boss yelling at his employee during stressed work hours or a teammate being toxic while attempting to communicate. " +
              "Apart from not conveying your message it may also impose several negative consequences such as a lowered working morale or a hostile atmosphere under which nobody can thrive. When is the last time you used negative language? What do you think led you to do that and in hindsight what could you have done differently? Personal awareness plays a major role in using positive language and understanding the benefits of a positive attitude will get your a long way."
            };
            var section2 = new CaseSection()
            {
                Title = "Using ‘I’ statements",
                Body = "‘I’ statements, rather than ‘you’ statements, often yield better results in verbal exchanges. For example, ‘I need more information to make a decision’ sounds much better than, ‘You need to give me more information before I can make a decision’. The reason the ‘I’ statements sounds better is that you are saying what you need rather telling someone what they should do. Furthermore you take responsibility and don’t push the conversation into a matter of fault or guilt."
            };
            var section3 = new CaseSection()
            {
                Title = "Assertiveness versus aggression",
                Body = "Assertiveness (often through the use of ‘I’ statements) is stating what you plan to do. Instead of coming across as hostile, you are making a statement about something you feel or perceive. Aggression is completely different and is usually perceived as hostile or unfriendly behaviour. It often uses the word ‘you’. People can become unhappy when you tell them what to do. Even when talking to employees it is wise to soften language when asking them to perform tasks, as they are likely to respond better to requests than orders. In a scenario where you want to nade long A for example try to phrase yourself with “Hey guys let’s through nades long A” rather than the more commanding “EVERYONE go nade long A!”. " +
              "\n \n Consistent assertiveness shows others that you’re confident and open to suggestion, but won’t be taken advantage of, " +
              "leading to a mutually acceptable outcome.Mastering this is another key skill where personal awareness is very important. If you are aware of how others perceive you - you will guaranteed see better results."
            };
            var section4 = new CaseSection()
            {
                Title = "Speaking style",
                Body = "Speaking style means the tone, pitch, accent, volume and pace of your voice. Being a skilled communicator you can adjust these based on the situation to convey your points more clearly. \n \n The same sentence can be conveyed, and understood, in entirely different ways based on the way in which it is said. People you speak to can be motivated by a positive speaking style, just as they can be put off by a negative style. " +
              " \n \n You should always try to speak with a positive voice -avoid monotone responses, or talking too quickly or slowly.Be as clear as possible and try to engage the listener, as this is far more likely to promote the response you are after than if they leave the conversation deflated. It’s quite common to meet people in matchmaking who quickly becomes discouraged after a couple rounds -" +
              " maybe even close to rage quitting the game.Whenever they talk or write ingame their attitude infects the entire team and not only does it make the game less fun it also decreases the team’s performance and splits them instead of working as a unit.You’re 100 times more likely to listen to a self-confident and inspirational player" +
              " who is able to look beyond a couple of bad rounds and see things in a bigger picture."
            };
            var section5 = new CaseSection()
            {
                Title = "Summary",
                Body = "Communication plays a major role in several aspects of our life and is the foundation of all human interaction. Being a good communicator in real life will almost certainly also make you a better communicator in cs:go - so acknowledging the power of communication is a fundamental step towards improving yourself. The beauty of such a broad skill is that you can practice it every day in different arenas; The supermarket, the classroom, on a job or ingame and mastering communication in one area will have great positive effects on others."
            };
            context.CaseSections.AddRange(section1, section2, section3, section4, section5);
            context.SaveChanges();

            caseEntity.Sections.Add(section1);
            caseEntity.Sections.Add(section2);
            caseEntity.Sections.Add(section3);
            caseEntity.Sections.Add(section4);
            caseEntity.Sections.Add(section5);

            /*************************************************/
            /********** QUIZ *********************************/
            /*************************************************/
            var question1 = new Question()
            {
                Text = "What is a common downside of not communication properly, according to Røj?",
                Answer = "You check the same spots as your teammates",
                Difficulty = "easy",
            };
            var question2 = new Question()
            {
                Text = "If you are frequently surprised during your games, what does this indicate?",
                Answer = "The picture in your head doesn´t fit the reality of the game",
                Difficulty = "hard",
            };
            var question3 = new Question()
            {
                Text = "What is the effect of good communication according to Røj?",
                Answer = "It increases your teammates reaction time",
                Difficulty = "hard",
            };
            var question4 = new Question()
            {
                Text = "What defines good communication?",
                Answer = "It is accurate, necessary and well timed",
                Difficulty = "medium",
            };
            var question5 = new Question()
            {
                Text = "What is a good program for recording and watching your own play?",
                Answer = "Steam",
                Difficulty = "easy",
            };
            var question6 = new Question()
            {
                Text = "What is one of the simplest ways to get better at CS:GO, according to Røj?",
                Answer = "Play and keep playing. When done, start again.",
                Difficulty = "easy",
            };
            var question7 = new Question()
            {
                Text = "What should you do, if your team has no plan?",
                Answer = "Take the lead and instantly make a plan",
                Difficulty = "medium",
            };
            context.Questions.AddRange(question1, question2, question3, question4, question5, question6, question7);
            context.SaveChanges();
            var courseQuiz = new CourseQuiz()
            {
                Name = "Quiz",
                Section = Section.Quiz,
                LectureType = LectureType.Quiz,
                DisplayOrder = 5
            };
            courseQuiz.Questions.Add(question1);
            courseQuiz.Questions.Add(question2);
            courseQuiz.Questions.Add(question3);
            courseQuiz.Questions.Add(question4);
            courseQuiz.Questions.Add(question5);
            courseQuiz.Questions.Add(question6);
            courseQuiz.Questions.Add(question7);

            context.SaveChanges();

            var proContent = new CourseVideo()
            {
                Name = "Pro CS:GO content",
                Section = Section.Game,
                LectureType = LectureType.Video,
                DisplayOrder = 6,
                Instructor = instructor2
            };
            context.Lectures.Add(proContent);
            context.SaveChanges();

            await videoService.AddVideo(instructor2.Id, proContent.Id, "Good & bad communication", "C:\\Users\\inter\\Desktop\\AWS_Videos\\good-bad-communication.mp4");
            await videoService.AddVideo(instructor2.Id, proContent.Id, "How do pros practice communication?", "C:\\Users\\inter\\Desktop\\AWS_Videos\\how-do-pros-practice-communication.mp4");
            await videoService.AddVideo(instructor2.Id, proContent.Id, "Get in the mind of a pro", "C:\\Users\\inter\\Desktop\\AWS_Videos\\get-in-the-mind of-a-pro.mp4");

            /*************************************************/
            /********** EXERCISES*****************************/
            /*************************************************/
            var exercise1 = new Exercise()
            {
                Description = "Play a game of CS:GO where you put great effort into communicating and keeping a positive atmosphere in the team.",
                IsRealLife = false
               
            };
            var exercise2 = new Exercise()
            {
                Description = "Think about a topic or something that happened today and try to communicate it to a family member or friend keeping all the things you have learned in mind.",
                IsRealLife = true
            };
            var exercise3 = new Exercise()
            {
                Description = "Try to put words on what good and bad communication is. Do you know anyone who is good at communication? Ask yourself why",
                IsRealLife = true
            };
            context.Exercises.Add(exercise1);
            context.Exercises.Add(exercise2);
            context.Exercises.Add(exercise3);

            context.SaveChanges();
            var exercises = new CourseExercise()
            {
                Name = "Exercises",
                Section = Section.Practice,
                LectureType = LectureType.Practice,
                DisplayOrder = 7,
                Description = "Let's take a look at some exercises you can do to practice your communication:",
            };
            exercises.Exercises.Add(exercise1);
            exercises.Exercises.Add(exercise2);
            exercises.Exercises.Add(exercise3);


            /*************************************************/
            /********** SUMMARY ******************************/
            /*************************************************/
            var summary = new CourseSummary()
            {
                Name = "Summary",
                Section = Section.Summary,
                LectureType = LectureType.Summary,
                DisplayOrder = 8,
                Summary = "This wraps up the communication course. Remember improving your communication is a process and doesn't happen overnight. You've already taken a solid step by acquiring knowledge about communication. Good communication is accurate, necessary and well-timed. Those are points you can transfer to other areas in your life such as the classroom or the football field - not just when you play computer",
            };

            /*************************************************/
            /********** ADD LECTURES *************************/
            /*************************************************/

            context.Lectures.Add(infoEntity);
            context.Lectures.Add(introductionEntity);
            context.Lectures.Add(caseEntity);
            context.Lectures.Add(courseQuiz);
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
                    IsReleased = true,
                    ImageUrl = "https://picsum.photos/600/600?random",
                };
                course1.Lectures.Add(infoEntity);
                course1.Lectures.Add(introductionEntity);
                course1.Lectures.Add(RealLifeLecture);
                course1.Lectures.Add(caseEntity);
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
                     Description = "",
                     ImageUrl = "https://picsum.photos/600/600?random",
                     IsReleased = false,
                 },
                 new Course
                 {
                     Name = "Teamwork in CS:GO",
                     UrlName = "teamwork-in-csgo",
                     Description = "",
                     ImageUrl = "https://picsum.photos/600/600?random",
                     IsReleased = false,
                 },
                 new Course
                 {
                     Name = "Problem solving in CS:GO2",
                     UrlName = "problem-solving-in-csgo",
                     Description = "",
                     ImageUrl = "https://picsum.photos/600/600?random",
                     IsReleased = false,
                 }
                );
                context.SaveChanges();
            }

        }
    }

}