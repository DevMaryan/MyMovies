using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using MyMovies.Models;
using MyMovies.Common.Exceptions;

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
                return RedirectToAction("Index", new { SuccessMessage = "Movie is successfully created." });
            }
            return View(movie);
        }
        // DELETE MOVIE
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteMovie(id);
                return RedirectToAction("Admin", new { SuccessMessage = "Movie is deleted successfully" }); // Anonymous object which sends message
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("Admin", new { ErrorMessage = ex.Message });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Info");
            }
        }
        // UPDATE MOVIE - Just Show the Movie
        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {  
                var update_movie = _service.GetMovieById(id);

                if (update_movie == null)
                {
                    return RedirectToAction("Error", "Info");
                }
                return View(update_movie);
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

        // UPDATE MOVIE - EDIT the Movie
        [HttpPost]

        public IActionResult Update(int id, string title, string imageurl, string genre, DateTime date)
        {
            try
            {   // Which movie to update?
                var update_movie = _service.GetMovieById(id);
                // Alright update the fields
                update_movie.Title = title;
                update_movie.ImageUrl = imageurl;
                update_movie.Genre = genre;
                update_movie.Date = date;
                // Movie null?
                if (update_movie == null)
                {
                    return RedirectToAction("Error", "Info");
                }
                // If not send it to Service to be updated
                _service.UpdateMovie(update_movie);
                // Return View of the movie
                return RedirectToAction("Admin", new { SuccessMessage = "Movie is successfully updated." });
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

        // DETAIL MOVIE
        public IActionResult Detail(int id)
        {
            try
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
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Info", new { ErrorMessage = ex.Message });
            }

        }

        // ADMIN TABLE
        public IActionResult Admin(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var all_movies = _service.GetAllMovies();
            return View(all_movies);
        }


    }
}
