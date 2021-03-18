using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;

namespace MyMovies.Services
{
    public class MoviesService : IMoviesService
    {
        public IMoviesRepository _movieRepository { get; set; }

        public MoviesService(IMoviesRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // Service -> Get All Movies -> Repository 
        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        // Service -> Get Movie id -> Repository by id
        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        // Service -> Repository -> Create Movie
        public void CreateMovie(Movie movie)
        {
            _movieRepository.CreateMovie(movie);
        }

        // Service -> Repository -> Get movie by title
        public List<Movie> GetMovieByTitle(string title)
        {
            if (title == null)
            {
                return _movieRepository.GetAllMovies();
            }
            else
            {
                return _movieRepository.GetByTitle(title);
            }

        }
        // Service -> Repository -> Delete Movie
        public void DeleteMovie(Movie movie)
        {
            _movieRepository.DeleteMovie(movie);
        }
        // Service -> Repository -> Update Movie
        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }

    }
}
