using System;
using System.Collections.Generic;
using System.Text;

namespace JMP_WU_Domain
{
    public class Salary
    {
        public int Id { get; set; }
        public int SalaryPerMonth { get; set; }



        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
