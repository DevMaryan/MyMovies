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
                Views = movie.Views,
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
                Comments = movie.Comments.Select(x => x.ToCommentModel()).ToList(),
                Ratings = movie.Ratings.Select(x => x.ToRatingModel()).ToList(),
                Likes = movie.Likes.Select(x => x.ToLikesModel()).ToList(),
                Views = movie.Views,
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

        public static MovieRatingModel ToRatingModel(this Rating score)
        {
            return new MovieRatingModel
            {
                Id = score.Id,
                Score = score.Score,
                MovieId = score.MovieId,
                Username = score.User.Username
            };
        }
        public static MovieLikesModel ToLikesModel(this Like liked)
        {
            return new MovieLikesModel
            {
                Id = liked.Id,
                Liked = liked.Liked,
                MovieId = liked.MovieId,
                UserId = liked.User.Id
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
