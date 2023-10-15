using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VirtualOffice
{
    internal static class ViewManager
    {
        

        public static ListViewItem UpdateEmployeeList(ListView employeeList, Employee employee)
        {
            ListViewItem item = new();
            item.Content = employee.GetInfo();
            item.Tag = employee;
            return item;
        }

        
    }
}
