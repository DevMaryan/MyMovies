using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using MyMovies.Common.Exceptions;

namespace MyMovies.Services
{
    public class MoviesService : IMoviesService
    {
        public IMoviesRepository _movieRepository { get; set; }

        public MoviesService(IMoviesRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // Service ->  Get All Movies -> Interface -> Repository 
        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        // Service -> Get Movie id -> Interface -> Repository by id
        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        // Service -> Repository -> Interface -> Create Movie
        public void CreateMovie(Movie movie)
        {
            movie.Date = DateTime.Now;
            _movieRepository.CreateMovie(movie);
        }

        // Service -> Repository -> Interface -> Get movie by title
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
        public void DeleteMovie(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if(movie == null)
            {
                throw new NotFoundException($"The movie with {id} was not found.");
            }
            else
            {
                _movieRepository.DeleteMovie(movie);
            }
        }
        // Service -> Repository -> Update Movie
        public void UpdateMovie(Movie movie)
        {
            var updatedMovie = _movieRepository.GetMovieById(movie.Id);
            if (updatedMovie != null)
            {
                updatedMovie.Title = movie.Title;
                updatedMovie.ImageUrl = movie.ImageUrl;
                updatedMovie.Description = movie.Description;
                updatedMovie.Genre = movie.Genre;
                updatedMovie.DateModified = DateTime.Now;
                _movieRepository.UpdateMovie(updatedMovie);
            }
            else
            {
                throw new NotFoundException($"The movie with id {movie.Id} was not found");
            }
        }
    }
}
