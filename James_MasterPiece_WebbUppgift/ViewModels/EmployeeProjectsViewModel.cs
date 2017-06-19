using JMP_WU_Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace James_MasterPiece_WebbUppgift.ViewModels
{
    public class EmployeeProjectsViewModel
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public List<SelectListItem> AllProjects { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
