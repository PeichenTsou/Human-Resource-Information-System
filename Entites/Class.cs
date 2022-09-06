using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_WPF.Entites
{
    public enum ClassType { Lecture, Tutorial, Practical, Workshop }

    public class Class : Activity
    {
        public string unitCode { get; set; }
        public string campus { get; set; }
        public ClassType ClassType { get; set; } //enum (defined as above)
        public string roomLocation { get; set; }

        override public string ToString()
        {
            return weekDay + ", " + startTime.ToString("HH:mm") + "-" + endTime.ToString("HH:mm") + "       " + ClassType + "      " + roomLocation + "       " + campus + "       " + staffName;
        }

    }
}