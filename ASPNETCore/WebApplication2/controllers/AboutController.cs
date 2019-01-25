using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blank.controllers
{
    [Route("about")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "10086";
        }

        [Route("country")]
        public String Country()
        {
            return "中国";
        }
    }
}
