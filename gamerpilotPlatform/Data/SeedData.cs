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

            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        Name = "Communication in CS:GO",
                        UrlName = "communication-in-csgo",
                        Description = "This course is about communication in CS:GO..",
                        ImageUrl = "https://picsum.photos/600/600?random",
                    },
                    new Course
                    {
                        Name = "Strategy in CS:GO",
                        UrlName = "strategy-in-csgo",
                        Description = "This course is about strategy in CS:GO..",
                        ImageUrl = "https://picsum.photos/600/600?random",
                    }
                    ,
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
