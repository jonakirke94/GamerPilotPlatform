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
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            context.Users.AddRange(
                 new User
                 {
                     Email = "Test@Test.dk",
                     Username = "TestUser",
                     Password = "AQAAAAEAACcQAAAAENuhnbOeQxFUC7dJYhi7C7lLH7dwXWzZ8EtLSkrouqbN8SBw6t43z36wFlnXfx1g=="
                 },
                    new User
                    {
                        Email = "Dum@Dum.dk",
                        Username = "DumUser",
                        Password = "AQAAAAEAACcQAAAAENuhnbOeQxFUC7dJYhi7C7lLH7dwXWzZ8EtLSkrouqbN8SBw6t43z36wFlnXfx1g=="
                    }

            );
            context.SaveChanges();

        }
    }
}
