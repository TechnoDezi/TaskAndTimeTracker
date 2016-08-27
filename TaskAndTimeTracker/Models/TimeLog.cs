using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndTimeTracker.Models
{
    public class TimeLog
    {
        public string Id { get; set; }
        public DateTime DateLogged { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public string DurationString { get; set; }
    }
}
