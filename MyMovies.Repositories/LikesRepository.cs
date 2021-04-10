using Microsoft.EntityFrameworkCore;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class LikesRepository : ILikeRepository
    {
        public readonly MoviesDbContext _context;

        public LikesRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public void AddLike(Like liked)
        {
            _context.Likes.Add(liked);
            _context.SaveChanges();
        }

        public Like GetLikeById(int id)
        {
            return _context.Likes.FirstOrDefault(x => x.Id == id);
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Include(x => x.Comments).ThenInclude(x => x.User).Include(x => x.Ratings).ThenInclude(x => x.User).Include(x => x.Likes).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == id);
        }
        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public void RemoveLike(Like like)
        {
            _context.Likes.Remove(like);
            _context.SaveChanges();
        }

        public bool FindUserLike(int id)
        {
            return _context.Likes.Any(x => x.UserId==id);
        }
        public Like FindMovieId(int movieid)
        {
            return _context.Likes.FirstOrDefault(x => x.MovieId == movieid);
        }

    }
}
