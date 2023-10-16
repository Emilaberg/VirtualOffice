using System;
using System.Windows;

namespace VirtualOffice
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        private int employeeId;
        private Employee? _employee;

        public EditEmployee(int EmployeeId)
        {

            InitializeComponent();

            this.employeeId = EmployeeId;
            ShowData();
        }
        //Gets the correct employee and calls the populate class to show the employees data.
        public void ShowData()
        {
            //populate departments
            foreach (Department department in Enum.GetValues(typeof(Department)))
            {
                cbDepartment.Items.Add(department);
            }

            //Get correct employee.
            foreach (Employee employee in employeeManager.employees)
            {
                if (employee.GetId() == employeeId)
                {
                    _employee = employee;
                }
            }
            PopulateData();
        }

        //Sets all the inputs to the employees information
        private void PopulateData()
        {
            lblEmployee.Content = $"Edit {_employee!.FullName}";
            txtFname.Text = _employee.FirstName;
            txtLname.Text = _employee.Lastname;
            txtAge.Text = _employee.Age.ToString();
            txtFullName.Text = _employee.FullName;
            txtBio.Text = _employee.ShowBio();
            txtSalary.Text = _employee.Salary.ToString();
            cbDepartment.SelectedIndex = (int)_employee.Department;
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to remove the employee?", "WARNING", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {

                employeeManager.employees.RemoveAll(e => e.GetId() == employeeId);
                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();

            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (Employee employee in employeeManager.employees)
            {
                if (employee.GetId() == employeeId)
                {
                    employee.FirstName = txtFname.Text;
                    employee.Lastname = txtLname.Text;
                    employee.Age = int.Parse(txtAge.Text);
                    employee.FullName = txtFullName.Text;
                    employee.Bio = txtBio.Text;
                    employee.Salary = int.Parse(txtSalary.Text);

                }
            }

            MessageBoxResult result = MessageBox.Show("Do you want to save the changes", "WARNING", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();

            }
        }

        private void OnTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txtFullName.Text = $"{txtFname.Text} {txtLname.Text}";
        }
    }
}
