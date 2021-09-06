using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SEDCWebApplication.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
         
            ViewBag.ExceptionMessage = exception.Error.Message;
            return View();
        }

        [Route("ErrorStatus/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ExceptionMessage = "Trazena strana ne postoji";
                    break;
            }


            return View("NotFound");
        }
    }
}
