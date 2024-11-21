using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrinOwensProject2.Models
{
    internal class PreviousSessionData
    {
        public List<(string word, DateTime time, int points)> ValidWords { get; set; }
        public List<(string word, DateTime time, string reason)> InvalidWords { get; set; }
        public int Timer { get; set; }
    }
}
