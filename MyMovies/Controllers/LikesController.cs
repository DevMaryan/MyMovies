using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class LikesController : Controller
    {
        public readonly ILikesService _likesService;

        public LikesController(ILikesService likesService)
        {
            _likesService = likesService;
        }


        public IActionResult Add(int id)
        {
            try
            {
                var user_id = int.Parse(User.FindFirst("Id").Value);
                _likesService.Add(id, user_id);

                return RedirectToAction("Detail", "Home", new { id = id });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home", new { ErrorMessage = "Nesto se sluci" });
            }
        }
        public IActionResult Remove(int id)
        {
            var user = int.Parse(User.FindFirst("id").Value);

            var the_like = _likesService.GetLikeId(id);

            var the_user = the_like.UserId;

            if (the_like != null && user == the_user)
            {
                _likesService.RemoveLike(the_like);
                return RedirectToAction("Detail", "Home", new { id = the_like.MovieId });
            }
            else
            {
                return RedirectToAction("Error", "Info");
            }
        }
    }
}
