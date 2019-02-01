using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Models;
using ContosoUniversity.Data;
using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;
        public HomeController(SchoolContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
             var groups = from s in _context.Students
                         group s by s.EnrollmentDate into dateGruop
                         select new EnrollmentDateGroup()
                         {
                            EnrollmentDate = dateGruop.Key,
                            StudentCount = dateGruop.Count()
                         };

            return View(await groups.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
