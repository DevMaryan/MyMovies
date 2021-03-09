using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovies.Models;

namespace MyMovies.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var movie1 = new Movie();
            movie1.Id = 1;
            movie1.Title = "WW84";
            movie1.ImageUrl = "https://bit.ly/2MZpH6i";
            movie1.Description = "Diana Prince lives quietly among mortals in the vibrant, sleek 1980s-- an era of excess driven by the pursuit of having it all.";
            movie1.Genre = "Action";
            movie1.Date = DateTime.UtcNow;

            var movie2 = new Movie();
            movie2.Id = 2;
            movie2.Title = "Tenet";
            movie2.ImageUrl = "https://bit.ly/3bwsIEU";
            movie2.Description = "Quietly among mortals in the vibrant, sleek 1980s-- an era of excess driven by the pursuit of having it all.";
            movie2.Genre = "Drama";
            movie2.Date = DateTime.UtcNow;

            var movie3 = new Movie();
            movie3.Id = 3;
            movie3.Title = "Avengers: Endgame";
            movie3.ImageUrl = "https://bit.ly/2PJO20Z";
            movie3.Description = "Quietly among mortals in the vibrant, sleek 1980s-- an era of excess driven by the pursuit of having it all.";
            movie3.Genre = "SCI-FI";
            movie3.Date = DateTime.UtcNow;

            var movie4 = new Movie();
            movie4.Id = 4;
            movie4.Title = "The King's Man";
            movie4.ImageUrl = "https://bit.ly/3c8QWUs";
            movie4.Description = "Mortals in the vibrant, sleek 1980s-- an era of excess driven by the pursuit of having it all.";
            movie4.Genre = "Action";
            movie4.Date = DateTime.UtcNow;

            var movie5 = new Movie();
            movie5.Id = 5;
            movie5.Title = "News of the World";
            movie5.ImageUrl = "https://bit.ly/2Oh6KN9";
            movie5.Description = "Five years after the end of the Civil War, Capt. Jefferson Kyle Kidd crosses paths with a 10-year-old girl taken by the Kiowa people. Forced to return to her aunt and uncle, Kidd agrees to escort the child across the harsh and unforgiving plains of Texas";
            movie5.Genre = "Drama";
            movie5.Date = DateTime.UtcNow;

            var movie6 = new Movie();
            movie6.Id = 6;
            movie6.Title = "Monster Hunter";
            movie6.ImageUrl = "https://bit.ly/3v2KWFw";
            movie6.Description = "Behind our world, there is another -- a world of dangerous and powerful monsters that rule their domain with deadly ferocity. When Lt. Artemis and her loyal soldiers are transported from our world to the new one, the unflappable lieutenant receives the shock of her life.";
            movie6.Genre = "SCI-FI";
            movie6.Date = DateTime.UtcNow;

            var movies = new List<Movie> { movie1, movie2, movie3, movie4, movie5, movie6 };

            return View(movies);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Admin()
        {
            var movie1 = new Movie();
            movie1.Id = 1;
            movie1.Title = "WW84";
            movie1.ImageUrl = "https://bit.ly/2MZpH6i";
            movie1.Description = "Diana Prince lives quietly among mortals in the vibrant, sleek 1980s-- an era of excess driven by the pursuit of having it all.";
            movie1.Genre = "Action";
            movie1.Date = DateTime.UtcNow;

            var movie2 = new Movie();
            movie2.Id = 2;
            movie2.Title = "Tenet";
            movie2.ImageUrl = "https://bit.ly/3bwsIEU";
            movie2.Description = "Quietly among mortals in the vibrant, sleek 1980s-- an era of excess driven by the pursuit of having it all.";
            movie2.Genre = "Drama";
            movie2.Date = DateTime.UtcNow;

            var movie3 = new Movie();
            movie3.Id = 3;
            movie3.Title = "Avengers: Endgame";
            movie3.ImageUrl = "https://bit.ly/2PJO20Z";
            movie3.Description = "Quietly among mortals in the vibrant, sleek 1980s-- an era of excess driven by the pursuit of having it all.";
            movie3.Genre = "SCI-FI";
            movie3.Date = DateTime.UtcNow;

            var movie4 = new Movie();
            movie4.Id = 4;
            movie4.Title = "The King's Man";
            movie4.ImageUrl = "https://bit.ly/3c8QWUs";
            movie4.Description = "Mortals in the vibrant, sleek 1980s-- an era of excess driven by the pursuit of having it all.";
            movie4.Genre = "Action";
            movie4.Date = DateTime.UtcNow;

            var movie5 = new Movie();
            movie5.Id = 5;
            movie5.Title = "News of the World";
            movie5.ImageUrl = "https://bit.ly/2Oh6KN9";
            movie5.Description = "Five years after the end of the Civil War, Capt. Jefferson Kyle Kidd crosses paths with a 10-year-old girl taken by the Kiowa people. Forced to return to her aunt and uncle, Kidd agrees to escort the child across the harsh and unforgiving plains of Texas";
            movie5.Genre = "Drama";
            movie5.Date = DateTime.UtcNow;

            var movie6 = new Movie();
            movie6.Id = 6;
            movie6.Title = "Monster Hunter";
            movie6.ImageUrl = "https://bit.ly/3v2KWFw";
            movie6.Description = "Behind our world, there is another -- a world of dangerous and powerful monsters that rule their domain with deadly ferocity. When Lt. Artemis and her loyal soldiers are transported from our world to the new one, the unflappable lieutenant receives the shock of her life.";
            movie6.Genre = "SCI-FI";
            movie6.Date = DateTime.UtcNow;

            var movies = new List<Movie> { movie1, movie2, movie3, movie4, movie5, movie6 };

            return View(movies);
        }

    }
}
