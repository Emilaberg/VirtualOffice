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
using System.Windows.Shapes;

namespace VirtualOffice
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        public object EmployeeData { get; set; }
        public EditEmployee(Object employee)
        {
            this.EmployeeData = employee;

            InitializeComponent();
            ShowData();
        }

        public void ShowData()
        {
            txtBox.Text = EmployeeData.ToString();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to remove the employee?", "WARNING", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                int res = (int)EmployeeData.GetType().GetProperty("Id")!.GetValue(EmployeeData, null)!;

                employeeManager.employees.RemoveAll(e => e.GetId() == res);
                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();

            }
            else
            {

            }

            
        }
    }
}
