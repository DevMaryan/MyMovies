using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using MyMovies.Mappings;
using MyMovies.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Index(string title, string successMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            var movies = _service.GetMovieByTitle(title);

            var movieIndexModels = movies.Select(x => x.ToIndexModel()).ToList();

            return View(movieIndexModels);
        }

        // CREATE MOVIE 
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(MovieCreateModel movie)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var domainModel = movie.ToModel();
                    _service.CreateMovie(domainModel);
                    return RedirectToAction("Index", new { SuccessMessage = "Movie is successfully created." });
                }
                return View(movie);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }

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
                return View(update_movie.ToUpdateModel());
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

        public IActionResult Update(MovieUpdateModel movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateMovie(movie.ToModel());
                    // Return View of the movie
                    return RedirectToAction("Admin", new { SuccessMessage = $"Movie {movie.Title} is successfully updated." });
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
            return View(movie);
        }

        // DETAIL MOVIE
        public IActionResult Detail(int id)
        {
            try
            {
                var select_movie = _service.GetMovieById(id);

                if (select_movie == null)
                {
                    return RedirectToAction("Error", "Info");
                }

                return View(select_movie.ToDetailModel());

            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Info", new { ErrorMessage = ex.Message });
            }

        }

        // ADMIN TABLE
        [Authorize]
        public IActionResult Admin(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var all_movies = _service.GetAllMovies();

            var viewModels = all_movies.Select(x => x.ToAdminModel()).ToList();

            return View(viewModels);
        }


    }
}
