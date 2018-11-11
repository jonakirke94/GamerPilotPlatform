using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model
{
    public class GamerProfile
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
    }
}
