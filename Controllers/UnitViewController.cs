using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS_WPF.DatabaseAdaptor;
using HRIS_WPF.Entites; //add to use Staff class

namespace HRIS_WPF.Controllers
{
    public class UnitViewController
    {
        public List<Unit> UnitList = new List<Unit>();
        public List<Class> ClassList = new List<Class>();

        //To get Uni Lit (used in getFilteredUnitsList)
        public List<Unit> getUnitList()
        {
            MySQLAdapter adapter2 = new MySQLAdapter();
            this.UnitList = adapter2.createUnitList();
            return this.UnitList;
        }
        //To filter Unit Lit (show both default and filtered)
        public List<Unit> getFilteredUnitsList(string searchCriteriaforUnit)
        {
            MySQLAdapter adapter = new MySQLAdapter();
            List<Unit> listToBeFiltered = adapter.createUnitList();
            var tempList = from Unit s in listToBeFiltered
                           where (string.IsNullOrEmpty(searchCriteriaforUnit) ||
                                     (!string.IsNullOrEmpty(searchCriteriaforUnit) &&
                                     (s.unitCode.Contains(searchCriteriaforUnit) || 
                                     s.unitTitle.Contains(searchCriteriaforUnit))))
                           select s;
            List<Unit> listFiltered = tempList.OrderBy(x => x.unitCode).ThenBy(x => x.unitTitle).ToList();
            return listFiltered;
        }

        ////To get filtered Class List
        public List<Class> getFilteredClassList(string unitid, string campus)
        {
            if (campus == "All Campus")
            {
                campus = "";
            }
            MySQLAdapter adapter = new MySQLAdapter();
            List<Class> listToBeFiltered = adapter.createClassList();
            var tempList = from Class s in listToBeFiltered
                            where (string.IsNullOrEmpty(unitid) ||
                            (!string.IsNullOrEmpty(unitid) && s.unitCode.Equals(unitid)
                            )) &&
                            (string.IsNullOrEmpty(campus) ||
                           (!string.IsNullOrEmpty(campus) &&
                           (s.campus.Equals(campus)
                           )))
                           //orderby s.weekDayEnum.ToString(), s.startTime.ToString() 
                           select s;
            List<Class> listFiltered = tempList.OrderBy(x => x.weekDayEnum).ThenBy(x => x.startTime).ToList();
            return listFiltered;
        }
    }
}
