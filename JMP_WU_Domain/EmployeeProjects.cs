using System;
using System.Collections.Generic;
using System.Text;

namespace JMP_WU_Domain
{
    public class EmployeeProjects
    {

        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }


    }
}
