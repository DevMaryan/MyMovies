using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class LikesService : ILikesService
    {
        private readonly ILikeRepository _likesRepository;

        public LikesService(ILikeRepository likesRepository)
        {
            _likesRepository = likesRepository;

        }

        public void Add(int movieId, int userId)
        {
            try
            {
                var movie = _likesRepository.GetMovieById(movieId);
                if(movie != null)
                {
                    var movie_id = movie.Id;

                    var newLike = new Like();
                    newLike.Liked = true;
                    newLike.MovieId = movie_id;
                    newLike.UserId = userId;
                    _likesRepository.AddLike(newLike);
                }

            }
            catch (Exception)
            {
                throw new NotFoundException($"The movie with id {movieId} was not found");
            }

        }
        public void RemoveLike(Like like)
        {

            _likesRepository.RemoveLike(like);

        }

        public Like GetLikeId(int id)
        {
            return _likesRepository.GetLikeById(id);
        }

        public bool FindUserLike(int id)
        {
            return _likesRepository.FindUserLike(id);
        }
    }
}
