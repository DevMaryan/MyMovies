using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface ILikesService
    {
        void Add(int movieId, int userId);
        Like GetLikeId(int id);

        bool FindUserLike(int id);
        void RemoveLike(Like like);
    }
}
