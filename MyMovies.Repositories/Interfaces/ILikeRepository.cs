using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface ILikeRepository
    {
        void AddLike(Like liked);
        User GetUserById(int userId);
        Movie GetMovieById(int id);
        Like GetLikeById(int id);
        void RemoveLike(Like the_like);
    }
}
