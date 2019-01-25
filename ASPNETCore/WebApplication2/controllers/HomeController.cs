using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blank.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public ObjectResult Index()
        {
            Employee e = new Employee() { ID = 1, Name = "哈哈" };
            return new ObjectResult(e);
        }
    }
}
