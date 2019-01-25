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
            Employee e = new Employee() { ID = 1, Name = "哈哈" };
            return View(e);
        }
    }
}
