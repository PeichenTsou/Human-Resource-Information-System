using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //must add to use MySql.Data (e.g. MySqlConnection)
using HRIS_WPF.Entites; //add to use Staff class
using System.Data; // add to use DataSet

namespace HRIS_WPF.DatabaseAdaptor
{
    public class MySQLAdapter
    {
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";
        string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3};SslMode=none", db, server, user, pass);

        private MySqlConnection conn;

        public MySQLAdapter() //?why same as class
        {
            //Create the connection object (does not actually make the connection yet)
            //Note that the HRIS case study database has the same values for its name, user name and password (to keep things simple)
            conn = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// To Create Staff List
        /// </summary>
        /// <returns>List of staffs</returns>
        public List<Staff> createStaffList()
        {
            List<Staff> staffs = new List<Staff>();
            try
            {
                var staffDataSet = new DataSet();
                var staffAdapter = new MySqlDataAdapter("select * from staff", conn);
                staffAdapter.Fill(staffDataSet, "staff");

                foreach (DataRow row in staffDataSet.Tables["staff"].Rows)  //to add each row of data to the Staff list
                {
                    staffs.Add(new Staff()
                    {
                        staffId = row["id"].ToString(),
                        familyName = row["family_name"].ToString(),
                        givenName = row["given_name"].ToString(),
                        title = row["title"].ToString(),
                        campus = row["campus"].ToString(),
                        phoneNumber = row["phone"].ToString(),
                        roomLocation = row["room"].ToString(),
                        emailAddress = row["email"].ToString(),
                        photo = row["photo"].ToString(),
                        Category = (Category)Enum.Parse(typeof(Category), row["category"].ToString()) //change to erum format
                    });
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return staffs;
        }

        /// <summary>
        /// To Create Unit List
        /// </summary>
        /// <returns>List of Unit</returns>
        public List<Unit> createUnitList()
        {
            List<Unit> units = new List<Unit>();
            try
            {
                var unitDataSet = new DataSet();
                var unitAdapter = new MySqlDataAdapter("select * from unit", conn);
                unitAdapter.Fill(unitDataSet, "unit");

                foreach (DataRow row in unitDataSet.Tables["unit"].Rows)  //to add each row of data to the unit list
                {
                    units.Add(new Unit()
                    {
                        unitCode = row["code"].ToString(),
                        unitTitle = row["title"].ToString(),
                        unitCoordinatorId = row["coordinator"].ToString()
                    });
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return units;
        }


        /// <summary>
        /// To Create Class List
        /// </summary>
        /// <returns>List of staffs</returns>
        public List<Class> createClassList()
        {
            List<Class> classes = new List<Class>();
            try
            {
                var classDataSet = new DataSet();
                var classAdapter = new MySqlDataAdapter("select c.*,concat(s.family_name, ', ', s.given_name , '(', s.title,')') as StaffName from class c INNER JOIN staff s on c.staff = s.id", conn); //issue
                classAdapter.Fill(classDataSet, "class");

                foreach (DataRow row in classDataSet.Tables["class"].Rows)  //to add each row of data to the Staff list
                {
                    classes.Add(new Class()
                    {
                        unitCode = row["unit_code"].ToString(),
                        campus = row["campus"].ToString(),
                        weekDay = row["day"].ToString(),
                        weekDayEnum = (WeekDayEnum)Enum.Parse(typeof(WeekDayEnum), row["day"].ToString()),
                        startTime = DateTime.Parse(row["start"].ToString()),
                        endTime = DateTime.Parse(row["end"].ToString()),
                        ClassType = (ClassType)Enum.Parse(typeof(ClassType), row["type"].ToString()), //change to erum format
                        roomLocation = row["room"].ToString(),
                        staffId = row["staff"].ToString(),
                        staffName = row["StaffName"].ToString()
                    });
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return classes;
        }

        /// <summary>
        /// To Create Consultation List
        /// </summary>
        /// <returns>List of Consultation</returns>
        public List<Consultation> createConsultationList()
        {
            List<Consultation> consultations = new List<Consultation>();
            try
            {
                var consultationDataSet = new DataSet();
                var consultationAdapter = new MySqlDataAdapter("select * from consultation", conn);
                consultationAdapter.Fill(consultationDataSet, "consultation");

                foreach (DataRow row in consultationDataSet.Tables["consultation"].Rows)  //to add each row of data to the consultation list
                {
                    consultations.Add(new Consultation()
                    {
                        weekDay = row["day"].ToString(),
                        startTime = DateTime.Parse(row["start"].ToString()),
                        endTime = DateTime.Parse(row["end"].ToString()),
                        staffId = row["staff_id"].ToString()
                    });
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return consultations;
        }


        /// <summary>
        /// To Create Staff List for Basic information Only ****
        /// </summary>
        /// <returns>List of staffs</returns>
        public List<Staff> createBasicStaffList()
        {
            List<Staff> staffs = new List<Staff>();
            try
            {
                var staffDataSet = new DataSet();
                var staffAdapter = new MySqlDataAdapter("select family_name, given_name, title, category from staff", conn);
                staffAdapter.Fill(staffDataSet, "staff");

                foreach (DataRow row in staffDataSet.Tables["staff"].Rows)  //to add each row of data to the Staff list
                {
                    staffs.Add(new Staff()
                    {
                        familyName = row["family_name"].ToString(),
                        givenName = row["given_name"].ToString(),
                        title = row["title"].ToString(),
                        Category = (Category)Enum.Parse(typeof(Category), row["category"].ToString()) //change to erum format
                    });
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return staffs;
        }







    }
 }

