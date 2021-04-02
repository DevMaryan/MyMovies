using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repositories
{
    public interface ICommentsRepository
    {

        void CreateComment(Comment comment);
        void DeleteComment(Comment comment);
        Comment GetCommentById(int id);
    }
}