using MyMovies.Models;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Genre = movie.Genre,
                Description = movie.Description,
                Date = movie.Date,
                DateModified = movie.DateModified,
                Comments = movie.Comments.Select(x => x.ToCommentModel()).ToList()
            };
        }
        public static MovieCommentModel ToCommentModel(this Comment comment)
        {
            return new MovieCommentModel
            {
                Id = comment.Id,
                Message = comment.Message,
                DateCreated = comment.DateCreated,
                Username = comment.User.Username
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
        public static UserDetailsModel ToDetailsModel(this User user)
        {
            return new UserDetailsModel()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username,
            };
        }
        public static UserUpdateModel ToUpdateModel(this User user)
        {
            return new UserUpdateModel()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
            };
        }
        public static UserAdminModel ToAdminModel(this User user)
        {
            return new UserAdminModel()
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username,
                IsAdmin = user.IsAdmin,
                DateCreated = user.DateCreated,
            };
        }


    }
}
