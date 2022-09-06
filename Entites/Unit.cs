using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_WPF.Entites
{
    public class Unit
    {
        public string unitCode { get; set; }
        public string unitTitle { get; set; }
        public string unitCoordinatorId { get; set; }

        /*override public string ToString()
        {
            return unitCode;
        }*/
    }
}
