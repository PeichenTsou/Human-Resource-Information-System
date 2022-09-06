using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS_WPF.DatabaseAdaptor;
using HRIS_WPF.Entites; //add to use Staff class

namespace HRIS_WPF.Controllers
{
   public class StaffViewController
    {
        //get default (if parameters are empty) and filtered Staff List
        public List<Staff> getFilteredStaffsList(string SearchCriteria, string category)
        {
            if (category == "All")
            {
                category = "";
            }
            MySQLAdapter adapter1 = new MySQLAdapter();
            List<Staff> listToBeFiltered = adapter1.createStaffList();
            var tempList = from Staff s in listToBeFiltered
                           where (string.IsNullOrEmpty(SearchCriteria) ||
                           (!string.IsNullOrEmpty(SearchCriteria) &&
                           (s.familyName.ToLower().Contains(SearchCriteria.ToLower()) || s.givenName.ToLower().Contains(SearchCriteria.ToLower())
                           ))) &&
                            (string.IsNullOrEmpty(category) ||
                           (!string.IsNullOrEmpty(category) &&
                           (s.Category.ToString() == category
                           ))) 
                           select s;
            List<Staff> listFiltered = tempList.OrderBy(x => x.familyName).ThenBy(x => x.givenName).ToList();
            return listFiltered;
        }

        //get default (if parameters are empty) and filtered Unit List under StaffView
        public List<Unit> getFilteredUnitsListInStaff(string Staffid)
        {
            MySQLAdapter adapter2 = new MySQLAdapter();
            List<Unit> listToBeFiltered2 = adapter2.createUnitList();
            var tempList2 = from Unit s in listToBeFiltered2
                            where (string.IsNullOrEmpty(Staffid) ||
                          (!string.IsNullOrEmpty(Staffid) && s.unitCoordinatorId.Equals(Staffid)
                          ))
                           select s;
            List<Unit> listFiltered2 = tempList2.OrderBy(x => x.unitCode).ThenBy(x => x.unitTitle).ToList();
            return listFiltered2;
        }

        //To get filtered Consultation List
        public List<Consultation> getFilteredConsultationList(string Staffid)
        {
            MySQLAdapter adapte3 = new MySQLAdapter();
            List<Consultation> listToBeFiltered3 = adapte3.createConsultationList();
            var tempList3 = from Consultation s in listToBeFiltered3
                                      where (string.IsNullOrEmpty(Staffid) ||
                                      (!string.IsNullOrEmpty(Staffid) && s.staffId.Equals(Staffid)
                                      ))
                            select s;
            List<Consultation> listFiltered3 = tempList3.OrderBy(x => x.weekDayEnum).ThenBy(x => x.startTime).ToList();
            return listFiltered3;
        }

        //To get filtered Class List (for get the Staff Status - current avability)
        public List<Class> getFilteredClassList(string staffId)
        {
            MySQLAdapter adapter = new MySQLAdapter();
            List<Class> listToBeFiltered = adapter.createClassList();
            var tempList = from Class s in listToBeFiltered
                           where (string.IsNullOrEmpty(staffId) ||
                           (!string.IsNullOrEmpty(staffId) && s.staffId.Equals(staffId)
                           ))
                           select s;
            List<Class> listFiltered = tempList.OrderBy(x => x.weekDayEnum).ThenBy(x => x.startTime).ToList(); //issue
            return listFiltered;
        }

        //get Staff Current avability (Status) : free/consultation/leture
        public string[] getStaffStatus(List<Consultation> _filteredConsultations, List<Unit> _filteredUnits)
        {
            string[] myList = new string[] { "", "", "" };

            if (_filteredConsultations.Count != 0 && _filteredUnits.Count != 0)
            {
                //consultation information(1)
                int countConList = _filteredConsultations.Count;
                //unit information(1)
                int unitConList = _filteredUnits.Count;

                //current time
                string nowWeekDay = DateTime.Now.DayOfWeek.ToString();
                TimeSpan nowTime = DateTime.Now.TimeOfDay;
                //TimeSpan nowTime = DateTime.Parse("9:05").TimeOfDay; //for test 
                //string nowWeekDay = "Wednesday"; //for test 

                // see if match consultation time
                int i = 0;
                while (i < countConList) 
                {
                    //consultation information(2)
                    string conWeekDay = _filteredConsultations[i].weekDay;
                    TimeSpan conStartTime = _filteredConsultations[i].startTime.TimeOfDay;  // ".TimeOfDay" to TimeSpan
                    TimeSpan conEndTime = _filteredConsultations[i].endTime.TimeOfDay;

                    if (nowTime > conStartTime && nowTime < conEndTime && nowWeekDay == conWeekDay)
                    {
                        myList[0] = "consulting";
                        return myList;
                    }
                    i++;
                }

                // see if match class time
                int x = 0;
                while (x < unitConList)
                {
                    //unit information(2)
                    string _unitCoordinatorId = _filteredUnits[x].unitCoordinatorId;
                    List<Class> classListForAvability = getFilteredClassList(_unitCoordinatorId);
                    int countclassList = classListForAvability.Count;

                    int y = 0;
                    while (y < countclassList)
                    {
                        //class information
                        string classWeekDay = classListForAvability[y].weekDay;
                        TimeSpan classStartTime = classListForAvability[y].startTime.TimeOfDay;  // ".TimeOfDay" to TimeSpan
                        TimeSpan classEndTime = classListForAvability[y].endTime.TimeOfDay;

                        if (nowTime > classStartTime && nowTime < classEndTime && nowWeekDay == classWeekDay)
                        {
                            //System.Windows.MessageBox.Show(_filteredUnits[x].unitCoordinatorId); //For test
                            myList[0] = "teaching";
                            //get unit and room information when avability is "teaching"
                            myList[1] = classListForAvability[y].unitCode.ToString();
                            myList[2] = "(@"+ classListForAvability[y].roomLocation.ToString() +")";
                            return myList;
                        }
                        y++;
                    }
                    x++;
                }
                myList[0] = "free";
                return myList;
            }

            myList[0] = "free";
            return myList;
        }
    }
}


///----record----
///
/////Time to print
///DateTime nowTime = DateTime.Parse(DateTime.Now.TimeOfDay.ToString()); //print use
///System.Windows.MessageBox.Show(nowWeekDay.ToString() + ", " + nowTime.ToString("HH:mm"));

