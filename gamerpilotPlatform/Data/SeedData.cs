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
    }
}
