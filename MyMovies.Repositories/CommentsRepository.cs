using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly MoviesDbContext _context;

        public CommentsRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetCommentByUserId(int userId)
        {
            var comments = _context.Comments.Where(x => x.UserId == userId).ToList();
            return comments;
        }

        public void DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public Comment GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);

        }


    }
}
