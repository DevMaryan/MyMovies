using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = "IsAdmin")]
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
                    if (Convert.ToBoolean(User.FindFirst("IsAdmin").Value))
                    {
                        return RedirectToAction("Admin", new { SuccessMessage = "The profile is updated." });
                    }
                    else
                    {
                        return RedirectToAction("Details", new { SuccessMessage = "Your profile is updated." });
                    }
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

        public IActionResult Delete(int id)
        {
            try
            {
                _usersService.DeleteUser(id);
                return RedirectToAction("Admin", new { SuccessMessage = "User deleted." });
            }
            catch (Exception)
            {
                return RedirectToAction("Info", "Error");
            }
        }

        public IActionResult Admin(string successMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            var all_users = _usersService.GetAllUsers();

            var viewModels = all_users.Select(x => x.ToAdminModel()).ToList();


            return View(viewModels);
        }

        // Make Admin Toggle
        public IActionResult MakeAdmin(int id)
        {
            var selected_user = _usersService.ToggleAdminRole(id);
            if(selected_user)
            {
                return RedirectToAction("Admin", new { SuccessMessage = $"User admin role is changed." });
            }
            else
            {
                return RedirectToAction("Admin", new { ErrorMessage = "User not found." });
            }

        }
    }
}
