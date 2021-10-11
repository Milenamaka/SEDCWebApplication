using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SEDCWeb1API.Helpers;
using SEDCWebApplication.BLL.logic.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SEDCWeb1API.MIddlewares
{
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;


        public ErrorHandlingMiddleware(RequestDelegate next, IConfiguration configuration, ILogger logger)
        {
            _next = next;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            UserDTO user = (UserDTO)context.Items["User"];
            if(user == null)
            {
                await _next(context);
            }
            else
            {
                await HandleUserRequest(context, user);
            }

        }

        private async Task HandleUserRequest(HttpContext context, UserDTO user)
        {
            try
            {
                LogEntryProperties log = new LogEntryProperties
                {
                    User = user.UserName,
                    Date = DateTime.Now,
                    Message = $"User with id {user.Id} call {context.Request.Path}"
                };

                _logger.Information(log.ToString());

                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleError(context, ex, user);
            }
        }

        private Task HandleError(HttpContext context, Exception ex, UserDTO user)
        {
            LogEntryProperties log = new LogEntryProperties
            {
                User = user.UserName,
                Date = DateTime.Now,
                Message = ex.Message
            };

            _logger.Error(log.ToString());

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return context.Response.WriteAsync(log.ToString());
        }
    }
}
