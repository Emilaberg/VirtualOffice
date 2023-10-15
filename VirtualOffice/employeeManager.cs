using System.Collections.Generic;

namespace VirtualOffice
{
    internal static class employeeManager
    {
        private static int id;
        public static List<Employee> employees = new();

        public static int CreateId()
        {
            return id++;
        }
    }
}
