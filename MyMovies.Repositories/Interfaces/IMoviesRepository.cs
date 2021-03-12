using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        List<Movie> GetAllMovies();

        Movie GetMovieById(int id);

        void CreateMovie(Movie movie);
    }
}
