using Microsoft.AspNetCore.Http;
using MyMovies.Common.Logs.Models;
using MyMovies.Common.Logs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Middleware
{
    public class ExceptionLoggingMiddelware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddelware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogService logService)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var logData = new LogData() { Type = LogType.Error, DateCreated = DateTime.Now, Message = ex.ToString() };
                logService.Log(logData);

                throw;
            }
        }
    }
}
