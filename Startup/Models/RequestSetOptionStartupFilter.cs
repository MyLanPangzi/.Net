using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Startup.Controllers;

namespace Startup.Models
{
    public class RequestSetOptionStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {

            return app =>
            {
                app.UseMiddleware<RequestSetOptionMiddleware>();
                next(app);
            };
        }
    }
}
