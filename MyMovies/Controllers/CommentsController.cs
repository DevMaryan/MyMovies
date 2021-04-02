using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentService)
        {
            _commentsService = commentService;
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add(CommentCreateModel commentCreateModel)
        {

            var userId = int.Parse(User.FindFirst("Id").Value);

            _commentsService.Add(commentCreateModel.Comment, commentCreateModel.MovieId, userId);

            return RedirectToAction("Detail", "Home", new { id = commentCreateModel.MovieId });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var comment = _commentsService.GetCommentId(id);
            if(comment != null)
            {
                _commentsService.DeleteComment(comment);
                return RedirectToAction("Detail", "Home", new { id = comment.MovieId });
            }
            else
            {
                return RedirectToAction("Error", "Info");
            }

        }
    }
}
