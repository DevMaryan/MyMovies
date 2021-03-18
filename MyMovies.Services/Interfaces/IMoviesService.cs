using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.Models;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAllMovies();
        List<Movie> GetMovieByTitle(string title);

        Movie GetMovieById(int id);

        void CreateMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}
