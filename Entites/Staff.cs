using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_WPF.Entites
{
    public enum Category { All, Academic, Technical, Admin, Casual }
    public class Staff
    {
        public string staffId { get; set; }
        public string familyName { get; set; }
        public string givenName { get; set; }
        public string title { get; set; }
        public string campus { get; set; }
        public string phoneNumber { get; set; }
        public string roomLocation { get; set; }
        public string emailAddress { get; set; }
        public string photo { get; set; } //url
        public Category Category { get; set; } //enum (defined as above)

        public string fullName
        {
            get
            {
                return familyName + ", " + givenName + " (" + title + ")";
            }
        }
    }
}
