using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_WPF.Entites
{
    public class Consultation : Activity
    {
        override public string ToString()
        {
            return weekDay + ", " + startTime.ToString("HH:mm") + " - " + endTime.ToString("HH:mm");
        }
    }
}
