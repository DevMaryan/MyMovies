using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using MyMovies.Models;

namespace MyMovies.Controllers
{
    public class HomeController : Controller
    {
        private IMoviesService _service { get; set; }

        public HomeController(IMoviesService service)
        {

            _service = service;
        }
        public IActionResult Index()
        {
            var movies = _service.GetAllMovies();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.CreateMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public IActionResult Detail(int id)
        {
            // Get Movie by ID
            var select_movie = _service.GetMovieById(id);
            // If movie doesnt exists
            if (select_movie == null)
            {
                return RedirectToAction("Error", "Info");
            }

            return View(select_movie);
        }
        public IActionResult Update()
        {
            return View();
        }


        public IActionResult Admin()
        {
            var all_movies = _service.GetAllMovies();
            return View(all_movies);
        }

    }
}
