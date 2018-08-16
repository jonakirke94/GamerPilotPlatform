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
                     Username = "TestUser",
                     Password = "123"
                 },
                    new User
                    {
                        Username = "DumUser",
                        Password = "123"
                    }

            );
            context.SaveChanges();

        }
    }
}
