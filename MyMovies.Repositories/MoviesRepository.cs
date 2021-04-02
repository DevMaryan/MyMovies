using Microsoft.EntityFrameworkCore;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public MoviesDbContext _context { get; set; }
        public MoviesRepository(MoviesDbContext context)
        {
            _context = context;
        }
        // Create Movie
        public void CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }


        // Get all Movies
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }


        // Get Movie by ID
        public Movie GetMovieById(int id)
        {
            return _context.Movies.Include(x => x.Comments).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        // Search - Get by Title
        public List<Movie> GetByTitle(string title)
        {
            return _context.Movies.Where(x => x.Title.Contains(title)).ToList();
        }

        // Delete Movie
        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }


        // Update Movie
        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
    }
}
