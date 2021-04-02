using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class CommentCreateModel
    {
        public int MovieId { get; set; }
        public string Comment { get; set; }
    }
}
