using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IRatingsRepository
    {
        void AddRating(Rating rate);
    }
}
