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



    }
}
