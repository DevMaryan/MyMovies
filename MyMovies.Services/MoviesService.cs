using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.Models;
using MyMovies.Repositories;


namespace MyMovies.Services
{
    public class MoviesService
    {
        public MoviesRepository _movieRepository { get; set; }
       
        public MoviesService()
        {
            _movieRepository = new MoviesRepository();
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public void DeleteMovieById(int id)
        {
            _movieRepository.DeleteMovie(id);
        }
    }
}
