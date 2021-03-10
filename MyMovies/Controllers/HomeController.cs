using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovies.Services;

namespace MyMovies.Controllers
{
    public class HomeController : Controller
    {
        private MoviesService _service { get; set; }

        public HomeController()
        {

            _service = new MoviesService();
        }
        public IActionResult Index()
        {
            var movies = _service.GetAllMovies();
            return View(movies);
        }
        public IActionResult Create()
        {
            return View();
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

        public IActionResult Delete(int id)
        {
            var selected_movie = _service.DeleteMovieById(id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Admin()
        {
            var all_movies = _service.GetAllMovies();
            return View(all_movies);
        }

    }
}
