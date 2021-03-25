using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult SignIn(string ErrorMessage)
        {
            ViewBag.ErrorMessage = ErrorMessage;
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel)
        {

            if (ModelState.IsValid)
            {

                var response = _authService.SignIn(signInModel.Username, signInModel.Password, HttpContext);

                if(response == true)
                {
                    return RedirectToAction("Index", "Home", new { SuccessMessage = $"User {signInModel.Username} is logged in." });
                }
                else
                {
                    return RedirectToAction("SignIn", "Auth", new { ErrorMessage = "Credentials not valid." });
                }
            }
            else
            {
                return View(signInModel);
            }

        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
