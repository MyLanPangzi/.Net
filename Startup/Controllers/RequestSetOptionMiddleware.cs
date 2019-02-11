using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Startup.Models;

namespace Startup.Controllers
{
    public class RequestSetOptionMiddleware
    {
        private readonly RequestDelegate _next;

        private IOptions<AppOptions> _options;
        private ILoggerFactory _loggerFactory;

        public RequestSetOptionMiddleware(RequestDelegate next, IOptions<AppOptions> options, ILoggerFactory loggerFactory)
        {
            this._next = next;
            this._options = options;
            this._loggerFactory = loggerFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            var logger = this._loggerFactory.CreateLogger<RequestDelegate>();
            logger.LogInformation("这里是RequestSetOptionMiddleware");

            string option = context.Request.Query["option"];
            if (!String.IsNullOrWhiteSpace(option))
            {
                this._options.Value.Option = WebUtility.HtmlEncode(option);
            }
            await this._next(context);
        }
    }
}
