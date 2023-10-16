using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VirtualOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Bool for toggle visibility
        private bool visibility = true;

        public MainWindow()
        {

            InitializeComponent();
            ToggleVisibility();

            //Clearing employeelist and adding departments to combobox and employees to listview
            UpdateUi();



        }
        //Updates the listview, this is called in the constructor.
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
                //runs a method in ViewManager that updates the employeelist on the front end. 
                lstEmployees.Items.Add(ViewManager.UpdateEmployeeList(lstEmployees, employee));
            }
        }

        private void BtnRegisterEmployee_Click(object sender, RoutedEventArgs e)
        {
            //Toggles visibility when clicking on the register button.
            ToggleVisibility();
        }

        private void ToggleVisibility()
        {
            string visibility;
            string visible = "Visible";
            string hidden = "hidden";

            if (this.visibility == false)
            {
                visibility = visible;
                this.visibility = true;
            }
            else
            {
                visibility = hidden;
                this.visibility = false;
            }

            if (visibility == "hidden")
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

            }
            else
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

                lblBio.Visibility = Visibility.Visible;
                txtBio.Visibility = Visibility.Visible;

                lblSalary.Visibility = Visibility.Visible;
                txtSalary.Visibility = Visibility.Visible;

                btnSave.Visibility = Visibility.Visible;
            }
        }

        //opens the editEmployee page
        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            //Selects the selected employee and saves it.
            ListViewItem selecteditem = (ListViewItem)lstEmployees.SelectedItem;
            Employee selectedViewTag = (Employee)selecteditem.Tag;


            //Creating a new edit window with the selected employee Id, shows it and closes the mainwindow.
            EditEmployee editEmployeeWindow = new EditEmployee(selectedViewTag.GetId());
            editEmployeeWindow.Show();
            Close();
        }

        //shows the edit button if you select a employee
        private void lstEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEditEmployee.Visibility = Visibility.Visible;
        }

        //creates and saves the new employee
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Skapa en ny employee och Sätt alla värden som man skrivit in till employee
            Employee newEmployee = new(employeeManager.CreateId(), txtFname.Text, txtLname.Text, int.Parse(txtAge.Text), decimal.Parse(txtSalary.Text), txtBio.Text, (Department)cbDepartment.SelectedItem);
            //skapa en listview 
            ListViewItem newItem = new();
            newItem.Content = newEmployee.GetInfo();
            newItem.Tag = newEmployee;
            newItem.BorderBrush = new SolidColorBrush(Colors.LimeGreen);
            newItem.BorderThickness = new Thickness(1);
            newItem.Padding = new Thickness(5);

            //lägg till employeen i listview:n
            lstEmployees.Items.Add(newItem);

            //lägg till den i EmployeeManager
            employeeManager.employees.Add(newEmployee);

            //Ressetta alla fields

            txtFname.Text = "";
            txtLname.Text = "";
            txtAge.Text = "";
            txtFullName.Text = "";
            txtBio.Text = "";
            txtSalary.Text = "";
            cbDepartment.SelectedIndex = -1;

        }
        //change the fullname text.
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            txtFullName.Text = $"{txtFname.Text} {txtLname.Text}";
        }
    }
}
