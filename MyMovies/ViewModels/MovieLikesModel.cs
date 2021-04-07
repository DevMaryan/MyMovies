using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieLikesModel
    {
        public int Id { get; set; }

        public bool Liked { get; set; }

        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}
