using MyMovies.Models;
using MyMovies.Repositories;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public void Add(string comment, int movieId, int userId)
        {
            var newComment = new Comment()
            {
                Message = comment,
                DateCreated = DateTime.Now,
                MovieId = movieId,
                UserId = userId,
            };
            _commentsRepository.CreateComment(newComment);
            
        }

        public void DeleteComment(Comment comment)
        {

            _commentsRepository.DeleteComment(comment);
        }

        public Comment GetCommentId(int id)
        {
            return _commentsRepository.GetCommentById(id);
        }


    }
}
