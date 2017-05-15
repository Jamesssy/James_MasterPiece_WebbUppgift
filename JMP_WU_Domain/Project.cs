using System;
using System.Collections.Generic;
using System.Text;

namespace JMP_WU_Domain
{
    public class Project
    {
        public int Id { get; set; }
        public int ProjectNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GoalCompletionDate { get; set; }
        public DateTime ActualCompletionDate { get; set; }
        public Status Status { get; set; } = 0;

        public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; }

    }
}
