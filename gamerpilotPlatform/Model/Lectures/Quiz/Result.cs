using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamerpilotPlatform.Model.Lectures.Quiz
{
    public class Result
    {
        public Question Question { get; set; }
        public bool IsCorrect { get; set; }
    }
}
