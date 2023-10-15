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

namespace VirtualOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool visibility = true;

        public MainWindow()
        {

            InitializeComponent();
            ToggleVisibility();
            
            UpdateUi();
            


        }

        private void UpdateUi()
        {
            lstEmployees.Items.Clear();
            
            //TEmporary


            foreach (Department department in Enum.GetValues(typeof(Department)))
            {
                cbDepartment.Items.Add(department);
            }

            foreach (Employee employee in employeeManager.employees)
            {
                lstEmployees.Items.Add(ViewManager.UpdateEmployeeList(lstEmployees, employee));
            }
        }

        private void BtnRegisterEmployee_Click(object sender, RoutedEventArgs e)
        {
            ToggleVisibility();
        }

        private void ToggleVisibility()
        {
            string visibility;
            string visible = "Visible";
            string hidden = "hidden";

            if(this.visibility == false)
            {
                visibility = visible;
                this.visibility = true;
            }
            else
            {
                visibility = hidden;
                this.visibility = false;
            }

            if(visibility == "hidden") 
            { 
                brEdit.Visibility = Visibility.Hidden;

                lblName.Visibility = Visibility.Hidden;
                txtFname.Visibility = Visibility.Hidden;

                lblLName.Visibility = Visibility.Hidden;
                txtLname.Visibility = Visibility.Hidden;
                
                lblFullName.Visibility = Visibility.Hidden;
                txtFullName.Visibility = Visibility.Hidden;
                
                lblAge.Visibility = Visibility.Hidden;
                txtAge.Visibility = Visibility.Hidden;
                
                lblDepartment.Visibility = Visibility.Hidden;
                cbDepartment.Visibility = Visibility.Hidden;

                lblBio.Visibility = Visibility.Hidden;
                txtBio.Visibility = Visibility.Hidden;

                lblSalary.Visibility = Visibility.Hidden;
                txtSalary.Visibility = Visibility.Hidden;
                
                btnSave.Visibility = Visibility.Hidden;

            } else
            {
                brEdit.Visibility = Visibility.Visible;

                lblName.Visibility = Visibility.Visible;
                txtFname.Visibility = Visibility.Visible;

                lblLName.Visibility = Visibility.Visible;
                txtLname.Visibility = Visibility.Visible;

                lblFullName.Visibility = Visibility.Visible;
                txtFullName.Visibility = Visibility.Visible;

                lblAge.Visibility = Visibility.Visible;
                txtAge.Visibility = Visibility.Visible;

                lblDepartment.Visibility = Visibility.Visible;
                cbDepartment.Visibility = Visibility.Visible;

                lblBio.Visibility = Visibility.Hidden;
                txtBio.Visibility = Visibility.Hidden;

                lblSalary.Visibility = Visibility.Visible;
                txtSalary.Visibility = Visibility.Visible;

                btnSave.Visibility = Visibility.Visible;
            }
        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selecteditem = (ListViewItem)lstEmployees.SelectedItem;
            Employee selectedViewTag = (Employee)selecteditem.Tag;

            foreach (Employee employee in employeeManager.employees)
            {
                if(employee.GetId() == selectedViewTag.GetId())
                {
                    
                    EditEmployee editEmployeeWindow = new EditEmployee(employee.GetData());
                    editEmployeeWindow.Show();

                    Close();
                }
            }
           
        }

        private void lstEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEditEmployee.Visibility = Visibility.Visible;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Skapa en ny employee och Sätt alla värden som man skrivit in till employee
            Employee newEmployee = new(employeeManager.CreateId(), txtFname.Text, txtLname.Text, int.Parse(txtAge.Text), decimal.Parse(txtSalary.Text), txtBio.Text, (Department)cbDepartment.SelectedItem);
            //skapa en listview 
            ListViewItem newItem = new();
            newItem.Content = newEmployee.GetInfo();
            newItem.Tag = newEmployee;
            //lägg till employeen i listview:n
            lstEmployees.Items.Add(newItem);
            
            //lägg till den i EmployeeManager
            employeeManager.employees.Add(newEmployee);

            //Ressetta alla fields

            txtFname.Text = "";
            txtLname.Text = "";
            txtAge.Text = "";
            txtFullName.Text = "";
            txtAge.Text = "";
            txtBio.Text = "";
            txtSalary.Text = "";
            cbDepartment.SelectedIndex = -1;

        }
    }
}
