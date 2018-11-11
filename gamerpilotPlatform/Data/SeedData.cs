using gamerpilotPlatform.Model.Lectures;
using gamerpilotPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamerpilotPlatform.Services;
using gamerpilotPlatform.Model.Lectures.Quiz;
using Microsoft.EntityFrameworkCore;

namespace gamerpilotPlatform.Data
{
    public class SeedData
    {
        private IVideoService videoService;
        private GamerpilotVodContext context;

        public SeedData(GamerpilotVodContext context, IVideoService videoService)
        {
            this.videoService = videoService;
            this.context = context;
        }


        public async Task Seed()
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            if (!context.Users.Any())
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
                    Name = "Anne Fiskaali",
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
                    Section = Model.Lectures.Section.Welcome,
                    DisplayOrder = 1,
                };

                /*************************************************/
                /********** COURSE INTRODUCTION ******************/
                /*************************************************/
                var introductionEntity = new CourseIntroduction()
                {
                    Name = "Course Introduction",
                    Section = Model.Lectures.Section.Welcome,
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
                    Section = Model.Lectures.Section.RealLife,
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
                //await videoService.AddVideo(instructor1.Id, RealLifeLecture.Id, "Into the psychology", "C:\\Users\\inter\\Desktop\\AWS_Videos\\teori-erhvervsliv.MP4");

                /*************************************************/
                /********** CASE *********************************/
                /*************************************************/
                var caseEntity = new CourseCase()
                {
                    Name = "A communication case",
                    Section = Model.Lectures.Section.RealLife,
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



                var proContent = new CourseVideo()
                {
                    Name = "Pro CS:GO content",
                    Section = Model.Lectures.Section.Game,
                    LectureType = LectureType.Video,
                    DisplayOrder = 5,
                    Instructor = instructor2
                };
                context.Lectures.Add(proContent);
                context.SaveChanges();

                //await videoService.AddVideo(instructor2.Id, proContent.Id, "Good & bad communication", "C:\\Users\\inter\\Desktop\\AWS_Videos\\good-bad-communication.mp4");
                // await videoService.AddVideo(instructor2.Id, proContent.Id, "How do pros practice communication?", "C:\\Users\\inter\\Desktop\\AWS_Videos\\how-do-pros-practice-communication.mp4");
                // await videoService.AddVideo(instructor2.Id, proContent.Id, "Get in the mind of a pro", "C:\\Users\\inter\\Desktop\\AWS_Videos\\get-in-the-mind of-a-pro.mp4");

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
                    Section = Model.Lectures.Section.Practice,
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
                    Section = Model.Lectures.Section.Summary,
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
                context.Lectures.Add(exercises);
                context.Lectures.Add(summary);

                context.SaveChanges();


                if (!context.Courses.Any())
                {
                    var course1 = new Course
                    {
                        Name = "Communication in CS:GO",
                        UrlName = "communication-in-csgo",
                        Description = "We take a closer look at how you can improve your communication skills both in CS:GO and in real life",
                        IsReleased = true,
                        Icon = "fas fa-comments"
                    };
                    course1.Lectures.Add(infoEntity);
                    course1.Lectures.Add(introductionEntity);
                    course1.Lectures.Add(RealLifeLecture);
                    course1.Lectures.Add(caseEntity);
                    course1.Lectures.Add(proContent);
                    course1.Lectures.Add(exercises);
                    course1.Lectures.Add(summary);

                    context.Courses.Add(course1);

                    context.Courses.AddRange(

                     new Course
                     {
                         Name = "Strategy in CS:GO",
                         UrlName = "strategy-in-csgo",
                         Description = "Strategy is an essential skill in both CS:GO and in many real life situations. Learn more",
                         IsReleased = false,
                         Icon = "fas fa-chess-rook"

                     },
                     new Course
                     {
                         Name = "Teamwork in CS:GO",
                         UrlName = "teamwork-in-csgo",
                         Description = "We take a closer look at Teamwork",
                         IsReleased = false,
                         Icon = "fas fa-people-carry"
                     },
                     new Course
                     {
                         Name = "Problem solving in CS:GO",
                         UrlName = "In this course we dive into problem solving in CS:GO and how you can apply your skills in real life",
                         Description = "",
                         IsReleased = false,
                         Icon = "fas fa-lightbulb"
                     }
                    );
                    context.SaveChanges();
                }

            }


            if (!context.Questions.Any())
            {
                var quiz = new CourseQuiz()
                {
                    Name = "Quiz",
                    Section = Model.Lectures.Section.Quiz,
                    LectureType = LectureType.Quiz,
                    DisplayOrder = 6
                };

                //question 1
                var question1 = new Question()
                {
                    Difficulty = "Easy",
                    QuestionText = "What defines good communication according to Anne Fiskaali?"
                };
                var choice1 = new Choice()
                {
                    IsCorrect = false,
                    Text = "It makes sure you always know what to do",
                };
                var choice2 = new Choice()
                {
                    IsCorrect = true,
                    Text = "It´s accurate, necessary and well timed",
                };
                var choice3 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Good communication is not having two snipers on your team",
                };
                var choice4 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Avoiding teamfire",
                };
                context.Choices.Add(choice1);
                context.Choices.Add(choice2);
                context.Choices.Add(choice3);
                context.Choices.Add(choice4);

                question1.Choices.Add(choice1);
                question1.Choices.Add(choice2);
                question1.Choices.Add(choice3);
                question1.Choices.Add(choice4);

                // question 2
                var question2 = new Question()
                {
                    Difficulty = "Easy",
                    QuestionText = "What should you do, if your team has no plan?"
                };
                var choice5 = new Choice()
                {
                    IsCorrect = true,
                    Text = "Take the lead and instantly make one",
                };
                var choice6 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Be silent. Better not mess anything up",
                };
                var choice7 = new Choice()
                {
                    IsCorrect = true,
                    Text = "Wait and see if things solve themselves",
                };
                var choice8 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Run to the nearest bombsite and hope it turns out well",
                };
                context.Choices.Add(choice5);
                context.Choices.Add(choice6);
                context.Choices.Add(choice7);
                context.Choices.Add(choice8);

                question2.Choices.Add(choice5);
                question2.Choices.Add(choice6);
                question2.Choices.Add(choice7);
                question2.Choices.Add(choice8);


                // question 3
                var question3 = new Question()
                {
                    Difficulty = "Easy",
                    QuestionText = "What is a good program for recording and watching your own play?"
                };
                var choice9 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Steam ",
                };
                var choice10 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Hola!",
                };
                var choice11 = new Choice()
                {
                    IsCorrect = true,
                    Text = "Plays",
                };
                var choice12 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Discord",
                };
                context.Choices.Add(choice9);
                context.Choices.Add(choice10);
                context.Choices.Add(choice11);
                context.Choices.Add(choice12);

                question3.Choices.Add(choice9);
                question3.Choices.Add(choice10);
                question3.Choices.Add(choice11);
                question3.Choices.Add(choice12);

                // question 4
                var question4 = new Question()
                {
                    Difficulty = "Easy",
                    QuestionText = "What is the effect of good communication according to Roj?"
                };
                var choice13 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Your teammates know which weapons to buy",
                };
                var choice14 = new Choice()
                {
                    IsCorrect = false,
                    Text = "You avoid friendly fire",
                };
                var choice15 = new Choice()
                {
                    IsCorrect = true,
                    Text = "It increases your teammates reaction time",
                };
                var choice16 = new Choice()
                {
                    IsCorrect = false,
                    Text = "You don’t block any of your teammates",
                };
                context.Choices.Add(choice13);
                context.Choices.Add(choice14);
                context.Choices.Add(choice15);
                context.Choices.Add(choice16);

                question4.Choices.Add(choice13);
                question4.Choices.Add(choice14);
                question4.Choices.Add(choice15);
                question4.Choices.Add(choice16);

                // question 5
                var question5 = new Question()
                {
                    Difficulty = "Easy",
                    QuestionText = "What is one of the simplest ways to get better at CS:GO according to Roj?"
                };
                var choice17 = new Choice()
                {
                    IsCorrect = true,
                    Text = "Play and keep playing. When done, start again",
                };
                var choice18 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Listen to CS:GO tutorials while you sleep",
                };
                var choice19 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Buy new gaming gear",
                };
                var choice20 = new Choice()
                {
                    IsCorrect = false,
                    Text = "Play without sound to sharpen your focus",
                };
                context.Choices.Add(choice17);
                context.Choices.Add(choice18);
                context.Choices.Add(choice19);
                context.Choices.Add(choice20);

                question5.Choices.Add(choice17);
                question5.Choices.Add(choice18);
                question5.Choices.Add(choice19);
                question5.Choices.Add(choice20);

                // question 6
                var question6 = new Question()
                {
                    Difficulty = "Easy",
                    QuestionText = "What´s a common downside of not communication according to Roj?"
                };
                var choice21 = new Choice()
                {
                    IsCorrect = true,
                    Text = "You check the same spots as your teammates",
                };
                var choice22 = new Choice()
                {
                    IsCorrect = false,
                    Text = "You all run like headless chickens",
                };
                var choice23 = new Choice()
                {
                    IsCorrect = false,
                    Text = "You run to the wrong bomb sites",
                };
                var choice24 = new Choice()
                {
                    IsCorrect = false,
                    Text = "You flash your teammates",
                };
                context.Choices.Add(choice21);
                context.Choices.Add(choice22);
                context.Choices.Add(choice23);
                context.Choices.Add(choice24);

                question6.Choices.Add(choice21);
                question6.Choices.Add(choice22);
                question6.Choices.Add(choice23);
                question6.Choices.Add(choice24);

                // question 7
                var question7 = new Question()
                {
                    Difficulty = "Easy",
                    QuestionText = "If you are frequently surprised during your games, what is this an indication of?"
                };
                var choice25 = new Choice()
                {
                    IsCorrect = false,
                    Text = "You are too easily scared",
                };
                var choice26 = new Choice()
                {
                    IsCorrect = true,
                    Text = "The picture in your head doesn't fit the reality of the game",
                };
                var choice27 = new Choice()
                {
                    IsCorrect = false,
                    Text = "You run too fast into combat",
                };
                var choice28 = new Choice()
                {
                    IsCorrect = false,
                    Text = "You forget to pay attention",
                };
                context.Choices.Add(choice25);
                context.Choices.Add(choice26);
                context.Choices.Add(choice27);
                context.Choices.Add(choice28);

                question7.Choices.Add(choice25);
                question7.Choices.Add(choice26);
                question7.Choices.Add(choice27);
                question7.Choices.Add(choice28);

                quiz.Questions.Add(question1);
                quiz.Questions.Add(question2);
                quiz.Questions.Add(question3);
                quiz.Questions.Add(question4);
                quiz.Questions.Add(question5);
                quiz.Questions.Add(question6);
                quiz.Questions.Add(question7);

                //add to lectures
                context.Lectures.Add(quiz);

                //add to course
                var course = context.Courses
                    .Include(x => x.Lectures)
                    .SingleOrDefault(x => x.Name == "Communication in CS:GO");
                course.Lectures.Add(quiz);

                context.SaveChanges();



            }

            if (!context.GamerProfiles.Any())
            {
                var profile1 = new GamerProfile
                {
                    Category = "Agreeableness",
                    Role = "Support player",
                    RoleDescription = "You are known to be kind, sharing, cooperative, warm and considerate. You value teamwork and generally have an optimistic view of others.",
                    Strengths = "As someone high in agreeableness you're flexible and willing to make compromises in cooperative situations.This makes you an especially valuable support player.Examples of how highly agreeable support players improve their team’s chances of success, are their willingness to give up kills, for helping out teammates in tight spots, and to drop weapons for skilled teammates short on cash.This willingness to share and compromise in terms of kill - count and cash will ultimately serve to increase their team’s chances of success.",
                    Weaknesses = "The desire for friendliness and team harmony can be valuable in any team, however such considerations may prevent you from sharing tactical and strategic opinions which goes against that of the majority."
                };
                context.GamerProfiles.Add(profile1);
                var profile2 = new GamerProfile
                {
                    Category = "Conscientiousness",
                    Role = "Team leader",
                    RoleDescription = "you're more careful and forward-thinking than most you meet online and in real-life but high conscientiousness also implies a general desire to do tasks well, and to take obligations to others seriously.You tend to be efficient, organized and attentive to detail as opposed to easy-going and disorderly.",
                    Strengths = "You possess excellent strategist and leadership qualities. An example would be your orientation to detail, which likely makes you more aware of when and how you should spend cash in-game, and when to save or drop for teammates.This is important when trying make the most of the teams total cash sum. As a result, you create a team - wide material advantage.In addition you inspire teammates by making them more conscientious themselves.This leads to better coordination, strategy and teamwork.",
                    Weaknesses = "Your flair for detail, coordination and planning makes you a great strategist, but you only really become a great leader, when able to get your team onbord.For someone high in conscientiousness, unresponsive teammates can become a huge frustration, impacting their own performance negatively - but this dosen't mean you should totally give up on strat calling, however! in fact, the key here is effective communication..."
                };
                context.GamerProfiles.Add(profile2);
                var profile3 = new GamerProfile
                {
                    Category = "Extraversion",
                    Role = "Entry fragger",
                    RoleDescription = "As someone high in Extraversion you love to play with high stakes. You seek plays and moves that get's your adrenaline pumping, often surprising opponents with risky moves.High risk is a natural part of your play, which turns the discomfort of others to your advantage.",
                    Strengths = "Being a fearless player, you have a laser like focus in clutch situations and the ability to act effectively without delay due to fear or shock.As an extrovert you are likely optimistic, high in positive emotion, outgoing and effective at communication.These are great attributes for any entry fragger.Being first to get information about opposing players, they should be able to pass this to their team in an effective manner.",
                    Weaknesses = "Rushing in and getting quick pickoffs is great but doesn’t work every time. Often you'll find yourself getting picked off uneccesarily due to overconfidence.Practice structure and listening to your teammates."
                };
                context.GamerProfiles.Add(profile3);
                var profile4 = new GamerProfile
                {
                    Category = "Openess",
                    Role = "Lurker",
                    RoleDescription = "You generally enjoy venturing beyond your comfort zone and to seek out the unknown. As a person you are original, imaginative, have broad interests, and are not afraid to take risks in your quests for new experiences, skills and knowledge.",
                    Strengths = "As someone high in openess you enjoy exploring the game world, thinking about and trying new strategies, tactics, and ways in which to oursmart your opponents. You're innovative, knowledgable, and generally like to think for yourself and define your own unique playstyle.  This makes you incredibly unpredictable in-game, and a great fit for the lurking playstyle, where your creativity and cool-headedness makes you great at flanking and picking off opponents when they least suspect it.",
                    Weaknesses = "While your unpredictable, creative and individualized playstyle can make you a nightmare to play against, it's important to recognize when to simply help out your teammates in conventional ways. While this may seem boring to you, it will often make a huge difference - especially when playing in a group of people you don't know."
                };
                context.GamerProfiles.Add(profile4);

                await context.SaveChangesAsync();
            }
        }
    }

}