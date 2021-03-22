using MyMovies.Models;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;

namespace MyMovies.Mappings
{
    public static class DomainModelExtensions
    {
        public static MovieAdminModel ToAdminModel(this Movie movie)
        {
            return new MovieAdminModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Genre = movie.Genre,
                Date = movie.Date,
                DateModified = movie.DateModified,
            };
        }

        public static MovieIndexModel ToIndexModel(this Movie movie)
        {
            return new MovieIndexModel()
            {
                Id = movie.Id,
                ImageUrl = movie.ImageUrl,
                Title = movie.Title,
                Genre = movie.Genre,
            };
        }

        public static MovieDetailModel ToDetailModel(this Movie movie)
        {
            return new MovieDetailModel()
            {
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Genre = movie.Genre,
                Description = movie.Description,
                Date = movie.Date,
                DateModified = movie.DateModified,
            };
        }

        public static MovieUpdateModel ToUpdateModel(this Movie movie)
        {
            return new MovieUpdateModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Description = movie.Description,
                Genre = movie.Genre,
            };
        }
    }
}
