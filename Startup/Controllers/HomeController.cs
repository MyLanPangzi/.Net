using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Startup.Models;

namespace Startup.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<AppOptions> _options;

        public HomeController(IOptions<AppOptions> options)
        {
            _options = options;
        }

        public IActionResult Index()
        {
            return Json(_options.Value.Option);
        }
    }
}
