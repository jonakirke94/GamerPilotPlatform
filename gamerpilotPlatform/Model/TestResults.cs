using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class TestResults
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public GamerProfile GamerProfile { get; set; }
        public int? GamerProfileId { get; set; }
    }
}
