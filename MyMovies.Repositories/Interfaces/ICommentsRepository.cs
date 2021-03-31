using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repositories
{
    public interface ICommentsRepository
    {
        List<Comment> GetAllComments();

        Comment GetCommentById(int id);

        void CreateComment(Comment comment);
        void DeleteComment(Comment comment);
        void UpdateComment(Comment comment);
    }
}