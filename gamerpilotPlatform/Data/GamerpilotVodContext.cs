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
    }
}
