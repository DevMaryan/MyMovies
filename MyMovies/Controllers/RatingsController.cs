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
    public class RatingsController : Controller
    {
        private readonly IRatingsService _ratingService;

        public RatingsController(IRatingsService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(MovieRatingModel movieRatingModel)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _ratingService.Add(movieRatingModel.Score, movieRatingModel.MovieId, userId);

            return RedirectToAction("Detail", "Home", new { id = movieRatingModel.MovieId });
        }
    }
}
