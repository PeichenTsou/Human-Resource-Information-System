using HRIS_WPF.Controllers;
using HRIS_WPF.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HRIS_WPF.Controllers;
using HRIS_WPF.Entites;

namespace HRIS_WPF.Views
{
    /// <summary>
    /// UserControl1.xaml 的互動邏輯
    /// </summary>
    public partial class StaffView : UserControl
    {
        StaffViewController staffViewController = new StaffViewController();

        public StaffView()
        {
            InitializeComponent();
        }

        //Select a staff in StaffList, and Details show in Staff Detail part
        private void StaffListBoxTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                Staff selected = (Staff)StaffListBoxTest.SelectedItem;
                if (selected != null)
                {
                 List <Unit> filteredUnits = staffViewController.getFilteredUnitsListInStaff(selected.staffId);
                unitListInStaffView.ItemsSource = filteredUnits;

                 List<Consultation> filteredConsultations = staffViewController.getFilteredConsultationList(selected.staffId);
                 consultationList.ItemsSource = filteredConsultations;

                string[] currentAvalibitityList;
                currentAvalibitityList = staffViewController.getStaffStatus(filteredConsultations, filteredUnits);
                currentAvailabilityLable.Content = currentAvalibitityList[0];
                currentAvailabilityLableforUnit.Content = currentAvalibitityList[1];
                currentAvailabilityLableforClass.Content = currentAvalibitityList[2];
            }
        }

        //Click to change the tab of mainwindow > go to unit details
        private void unitListInStaffView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            MainWindow obj = (MainWindow)Window.GetWindow(this);
            Unit selectedUnit = (Unit)unitListInStaffView.SelectedItem; //selected unit in StaffView
            if(selectedUnit != null)
            {
                obj.callUnit(selectedUnit.unitCode); //callUnit is in Mainwindow (sending selected UnitCode)
            }
        }

        //To ensure we refresh the StaffList after come back from UnitView
        public void ClearSearch() {
            searchCategory.SelectedValue = "All";
            seachText.Clear();
            ((ObjectDataProvider)this.FindResource("staffsList")).Refresh(); //refresh the Staff List (in xaml)
        }

        // From UnitView to StaffView > and select the Staff 
        public void goToStaffDetail(String StaffId)
        {
            if (StaffId != null)
            {
                var _staffObjectDataSource = ((ObjectDataProvider)this.FindResource("staffsList")); //get the object under StaffView (from xaml)
                if(_staffObjectDataSource != null)
                {
                    List<Staff> list = (List<Staff>)_staffObjectDataSource.Data; //get the data we need (object list of staff) from the object
                    var objStaff =(Staff) (from s in list where s.staffId == StaffId select s).Single(); //so can change from LIST to single OBJECT
                    var staffObjectIndex = list.IndexOf(objStaff); // !! IndexOf > can find the object in which index
                    StaffListBoxTest.SelectedIndex = staffObjectIndex; // change the selected index
                }
            }
        }

        //clear content when change category
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentAvailabilityLable != null)
            {
                currentAvailabilityLable.Content = ""; 
                currentAvailabilityLableforUnit.Content = ""; 
                currentAvailabilityLableforClass.Content = "";
            }
        }

    }
}






///-----record----
///
///public StaffView()
///{
///    InitializeComponent();

///    // set list of units to be everything (default) ---目前不需要
///    //List <Unit> filteredStaff = staffController.getFilteredUnitsListInStaff(null);
///    //unitListInStaffView.ItemsSource = filteredStaff;
///}

///        private void StaffListBoxTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
///        {
///            //if (e.AddedItems != null)
///            //{Staff selected = e.AddedItems[0] as Staff;
///                Staff selected = (Staff)StaffListBoxTest.SelectedItem;
///                if (selected != null)
///                {
///                 List<Unit> filteredUnits = staffController.getFilteredUnitsListInStaff(selected.staffId);
///                  unitListInStaffView.ItemsSource = filteredUnits;
///                }
///            //}
///        }