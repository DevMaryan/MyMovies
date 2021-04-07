using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IRatingsService
    {
        void Add(int scoreId, int movieId, int userId);
    }
}
