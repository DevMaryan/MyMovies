﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService userService)
        {
            this._usersService = userService;
        }

        [Authorize]
        public IActionResult Details(string successMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            var userId = User.FindFirst("Id").Value;
            var user = _usersService.GetDetails(userId);

            if(user == null)
            {
                return RedirectToAction("Error", "Info");
            }
            return View(user.ToDetailsModel());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _usersService.GetDetails(id);
            if(user == null)
            {
                return RedirectToAction("Index", "Home", new { ErrorMessage = "User not found."});
            }
            return View(user.ToUpdateModel());
        }

        [HttpPost]
        public IActionResult Update(UserUpdateModel user_id, string successMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            if (ModelState.IsValid)
            {
                try
                {
                    var the_user = _usersService.GetDetails(user_id.Id);
                    _usersService.UpdateUser(user_id.ToModel());
                    return RedirectToAction("Details", new { SuccessMessage = "Your profile is updated."});
                }
                catch (NotFoundException ex)
                {
                    return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", "Info");
                }
            }
            return View(user_id);
        }


    }
}