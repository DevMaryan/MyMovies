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
        public IActionResult SignIn(SignInModel signInModel, string returnUrl)
        {

            if (ModelState.IsValid)
            {

                var response = _authService.SignIn(signInModel.Username, signInModel.Password, signInModel.IsPersistent, HttpContext);

                if(response == true)
                {
                    if(returnUrl == null)
                    {
                        return RedirectToAction("Index", "Home", new { SuccessMessage = $"User {signInModel.Username} is logged in." });
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }

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

        // User SignOut
        public IActionResult SignOut()
        {
            _authService.SignOut(HttpContext);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
