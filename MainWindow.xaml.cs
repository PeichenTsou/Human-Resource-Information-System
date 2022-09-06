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
using HRIS_WPF.Views;
using HRIS_WPF.Entites;
using HRIS_WPF.Controllers;

namespace HRIS_WPF
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  
        }

        //To switch StaffView to UnitView
        public void callUnit(String id)
        {   
            HRISTab.SelectedIndex = 1;
            unitView.changeClassList(id); //changeClassList is in UnitView
        }

        //To switch UnitView to StaffView
        public void callStaff(String staffId)
        {
            HRISTab.SelectedIndex = 0;
            stafftView.ClearSearch();
            stafftView.goToStaffDetail(staffId); //go back to StaffView from UnitView
        }

    }
}
