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
        [Authorize]
        public IActionResult Remove(int id)
        {
            try
            {
                var user = int.Parse(User.FindFirst("id").Value);
                var like = _likesService.GetLikeId(id);
                var the_user = like.UserId;

                if(like != null && user == the_user)
                {
                    _likesService.RemoveLike(like);
                }
                return RedirectToAction("Detail", "Home", new { id = like.MovieId });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home", new { ErrorMessage = "Nesto se sluci" });
            }

        }

        //public IActionResult Remove(int like)
        //{
        //    try
        //    {
        //        _likesService.RemoveLike(like);
        //        return RedirectToAction("Detail", "Home");
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("Index", "Home", new { ErrorMessage = "Nesto se sluci" });
        //    }

        //}
    }
}
