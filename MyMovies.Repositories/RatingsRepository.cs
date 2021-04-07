using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories
{
    public class RatingsRepository : IRatingsRepository
    {
        public readonly MoviesDbContext _context;

        public RatingsRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public void AddRating(Rating rate)
        {
            _context.Ratings.Add(rate);
            _context.SaveChanges();
        }
    }
}
