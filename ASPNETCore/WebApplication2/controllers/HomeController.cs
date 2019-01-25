using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blank.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blank.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public ViewResult Index()
        {
            HomePageModel model = new HomePageModel();

            using (var context = new HelloWorldDbContext())
            {
                var employees = from e in context.Employees
                                select e;
                model.Employees = employees;

            }

            return View(model);
        }
    }

    public class HomePageModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}
