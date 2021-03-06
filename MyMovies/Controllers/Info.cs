using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class Info : Controller
    {
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult ActionNonSuccessful(string message)
        {
            ViewBag.Message = message;
            return View();
        }
        public IActionResult GeneralError()
        {
            return View();
        }
    }
}
