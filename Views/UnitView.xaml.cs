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
    /// UnitView.xaml 的互動邏輯
    /// </summary>
    public partial class UnitView : UserControl
    {
        UnitViewController unitViewController = new UnitViewController();

        public UnitView()
        {
            InitializeComponent();
        }

        //Get filtered class list when user selects unit from unit list 
        private void UnitListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit selected = (Unit)UnitListView.SelectedItem;
            ComboBoxItem selectedCombobox = (ComboBoxItem)filterCampus.SelectedItem;
            if (selected != null)
            {
                List<Class> filteredUnits = unitViewController.getFilteredClassList(selected.unitCode, selectedCombobox.Content.ToString());
                UnitDetailList.ItemsSource = filteredUnits;
                UnitTitleOfUnitDetail.Content = selected.unitCode;
            }
        }

        //Get filtered class list when user selects unit from unit list (when coming from StaffView)
        public void changeClassList(String id)
        {
            if (id != null)
            {
                List<Class> filteredUnits = unitViewController.getFilteredClassList(id, "");
                UnitDetailList.ItemsSource = filteredUnits;
                UnitDetailList.Items.Refresh(); //!! need this or it will not show on screen
                ((ObjectDataProvider)this.FindResource("unitList")).Refresh(); // so it will not be selecting any unit
                UnitTitleOfUnitDetail.Content = id;
            }
        }

       // filter the campus
        private void filterCampus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsInitialized)
            {
                ComboBoxItem selectedCombobox = filterCampus.SelectedItem as ComboBoxItem;
                if (selectedCombobox != null)
                {
                    Unit selected = null;
                    string selectedUnitcode = null;
                    if (UnitListView != null)
                    {
                        selected = (Unit)UnitListView.SelectedItem;
                    }
                    if (selected != null)
                    {
                        selectedUnitcode = selected.unitCode;
                    }
                    List<Class> filteredUnits = unitViewController.getFilteredClassList(selectedUnitcode, selectedCombobox.Content.ToString());
                    UnitDetailList.ItemsSource = filteredUnits;
                }
            }
        }

        //clear content when change search criteria
        private void seachText_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnitDetailList.ItemsSource = "";
            UnitTitleOfUnitDetail.Content ="";
        }

        //click the Staff Name under Unit Details List, and then go to StaffView (through MainWindow)
        private void hlkURL_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Class _selectedClass =(Class) ((System.Windows.FrameworkContentElement)sender).DataContext; //Get the data of object form selected one
            MainWindow obj = (MainWindow)Window.GetWindow(this);
            obj.callStaff(_selectedClass.staffId); //callUnit is in Mainwindow (sending the StaffId)
        }
    }
}
