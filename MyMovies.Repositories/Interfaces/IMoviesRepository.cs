using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        List<Movie> GetAllMovies();
        List<Movie> GetByTitle(string title);

        Movie GetMovieById(int id);

        void CreateMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}
