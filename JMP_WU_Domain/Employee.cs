using System;
using System.Collections.Generic;
using System.Text;

namespace JMP_WU_Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EmployedSince { get; set; }

        public virtual PhoneNr PhoneNr { get; set; }
        public virtual Address Address { get; set; }
        public virtual Salary Salary { get; set; }

        public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; }


    }
}
