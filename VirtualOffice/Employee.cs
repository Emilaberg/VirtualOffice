using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOffice
{
    internal class Employee : Person
    {
        public decimal Salary { get; set; }
        public string Bio { get; set; }

        public Department Department { get; set; }

        public Employee(int id, string firstName, string lastName, int age, decimal salary, string bio, Department department) : base(id, firstName, lastName, age)
        {
            this.Salary = salary;
            this.Bio = bio;
            this.Department = department;
        }


        public string GetInfo()
        {
            return $"{base.FullName}, Ålder: {base.Age} Lön: {Salary}, Kontor: {Department}";
        }

        public int GetId()
        {
            return base.id;
        }

        public object GetData()
        {
            return new
            {
                Id = base.id,
                Fname = base.FirstName,
                Lname = base.Lastname,
                FullName = base.FullName,
                Age = base.Age,
                salary = this.Salary,
                bio = this.Bio,
                Department = this.Department
            };
        }
    }
}
