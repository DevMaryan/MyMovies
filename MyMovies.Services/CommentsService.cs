using MyMovies.Models;
using MyMovies.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class CommentsService 
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public List<Comment> GetAll()
        {
            return _commentsRepository.GetAllComments();
        }
    }
}
