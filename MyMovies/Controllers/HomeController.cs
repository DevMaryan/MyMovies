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
        // Index PAGE
        public IActionResult Index(string title)
        {
            var movies = _service.GetMovieByTitle(title);
            return View(movies);
        }

        // CREATE MOVIE 
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
        // DELETE MOVIE
        public IActionResult Delete(Movie movie)
        {
            _service.DeleteMovie(movie);
            return RedirectToAction("Index");
        }
        // DETAIL MOVIE
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

        // ADMIN TABLE
        public IActionResult Admin()
        {
            var all_movies = _service.GetAllMovies();
            return View(all_movies);
        }


    }
}
