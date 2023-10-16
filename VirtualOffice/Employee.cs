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

        //returns a string to use in the employee listview 
        public string GetInfo()
        {
            return $"Fullname: {base.FullName}, Ålder: {base.Age} Lön: {Salary} kr, Kontor: {Department}";
        }

        //Gets the current employee ID
        public int GetId()
        {
            return base.id;
        }
        //shows the current employees bio, if there is none, the person bio will show instead.
        public override string ShowBio()
        {
            if (this.Bio.Trim().Length > 0)
            {
                return this.Bio;
            }
            else
            {
                return base.ShowBio();
            }
        }
    }
}
