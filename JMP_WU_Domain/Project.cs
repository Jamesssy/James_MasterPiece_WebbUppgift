using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JMP_WU_Domain
{
    public class Project
    {
        public int Id { get; set; }
        public int ProjectNo { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date, ErrorMessage = "This is not a valid date format. Pls enter in this format ex. 1973-02-31 ")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "This is not a valid date format. Pls enter in this format ex. 1973-02-31 ")]
        public DateTime? GoalCompletionDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "This is not a valid date format. Pls enter in this format ex. 1973-02-31 ")]
        public DateTime? ActualCompletionDate { get; set; }
        public Status? Status { get; set; } = 0;

        public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; }
        
    }
}
