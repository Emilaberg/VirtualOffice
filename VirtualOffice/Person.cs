using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOffice
{
    internal class Person
    {
        protected int id;
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }

        public Person(int id, string firstName, string lastName, int age)
        {
            this.id = id;
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.Age = age;
            this.FullName = firstName + " " + lastName;
        }
        public virtual string ShowBio()
        {
            return "Hi, I haven't added any bio yet!";
        }

    }
}
