using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_WPF.Entites
{

    public enum WeekDayEnum { Monday, Tuesday, Wednesday, Thursday, Friday }

    public class Activity
    {
        
        public string weekDay { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string staffId { get; set; }
        public string staffName { get; set; }
        public WeekDayEnum weekDayEnum { get; set; } //enum (defined as above)

        public string timePeriod
        {
            get
            {
                return startTime.ToString("HH:mm") + "-" + endTime.ToString("HH:mm");
            }
        }

    }
}
