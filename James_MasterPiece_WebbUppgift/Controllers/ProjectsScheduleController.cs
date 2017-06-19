using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JMP_WU_Domain;
using James_MasterPiece_WebbUppgift.Context;

namespace James_MasterPiece_WebbUppgift.Controllers
{
    public class ProjectsScheduleController : Controller
    {
        private readonly MasterPieceContext _context;

        public ProjectsScheduleController(MasterPieceContext context)
        {
            _context = context;
        }

        // GET: ProjectsSchedule
        public async Task<IActionResult> Index()
        {
            return View(await _context.Project.ToListAsync());
        }
        
    }
}
