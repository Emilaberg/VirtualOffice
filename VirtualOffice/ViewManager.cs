using System.Windows.Controls;

namespace VirtualOffice
{
    internal static class ViewManager
    {
        //Creates a new listviewitem with employee
        public static ListViewItem UpdateEmployeeList(ListView employeeList, Employee employee)
        {
            ListViewItem item = new();
            item.Content = employee.GetInfo();
            item.Tag = employee;
            return item;
        }


    }
}
