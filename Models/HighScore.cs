using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PerrinOwensProject2.Models
{
    public class HighScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }
    }
}