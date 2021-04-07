using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieRatingModel
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public int MovieId { get; set; }
        public string Username { get; set; }
    }
}
