using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class RatingsService : IRatingsService
    {
        private readonly IRatingsRepository _ratingsRepository;

        public RatingsService(IRatingsRepository ratingsRepository)
        {
            _ratingsRepository = ratingsRepository;

        }

        public void Add(int scoreId, int movieId, int userId)
        {
            var newRatings = new Rating()
            {
                Score = scoreId,
                MovieId = movieId,
                UserId = userId,

            };
            _ratingsRepository.AddRating(newRatings);
        }
    }
}