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
using MyMovies.Models;
using Microsoft.Extensions.Configuration;

namespace MyMovies.Controllers
{
    public class HomeController : Controller
    {
        private IMoviesService _service { get; set; }

        private IConfiguration _configuration { get; set; }

        public HomeController(IMoviesService service, IConfiguration configuration)
        {

            _service = service;
            _configuration = configuration;
        }
        // Index PAGE
        public IActionResult Index(string title, string successMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            var movies = _service.GetMovieByTitle(title);

            var IndexDataModel = new MovieIndexDataModel();

                
            var movieIndexModels = movies.Select(x => x.ToIndexModel()).ToList();
            IndexDataModel.IndexModels = movieIndexModels;

            // We are taking the count from appsettings.json
            int topRecipesCount = _configuration.GetValue<int>("SidebarConfig:MostRecentRecipesCount");
            int topMoviesCount = _configuration.GetValue<int>("SidebarConfig:TopRecipeCount");


            var mostRecentMovies = _service.GetMostRecentMovies(topRecipesCount);
            var topMovies = _service.GetTopMovies(topMoviesCount);

            IndexDataModel.SidebarData.MostRecentMovies = mostRecentMovies.Select(x => x.ToMovieSidebarModel()).ToList();
            IndexDataModel.SidebarData.TopMovies = topMovies.Select(x => x.ToMovieSidebarModel()).ToList();

            return View(IndexDataModel);
        }

        // CREATE MOVIE 
        [Authorize(Policy = "IsAdmin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [Authorize(Policy = "IsAdmin")]
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
        [Authorize(Policy = "IsAdmin")]
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
        [Authorize(Policy = "IsAdmin")]
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
        [Authorize(Policy = "IsAdmin")]
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
                var select_movie = _service.GetMovieDetails(id);

                if (select_movie == null)
                {
                    return RedirectToAction("Error", "Info");
                }
                var movieDetailDataModel = new MovieDetailDataModel();

                movieDetailDataModel.MovieDetail = select_movie.ToDetailModel();


                var mostRecentMovies = _service.GetMostRecentMovies(5);
                var topMovies = _service.GetTopMovies(5);

                movieDetailDataModel.SidebarData.MostRecentMovies = mostRecentMovies.Select(x => x.ToMovieSidebarModel()).ToList();
                movieDetailDataModel.SidebarData.TopMovies = topMovies.Select(x => x.ToMovieSidebarModel()).ToList();



                return View(movieDetailDataModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Info", new { ErrorMessage = ex.Message });
            }

        }

        // ADMIN TABLE
        [Authorize(Policy = "IsAdmin")]
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
