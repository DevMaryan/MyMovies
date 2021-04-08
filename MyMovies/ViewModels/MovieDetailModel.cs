using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieDetailModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateModified { get; set; }

        public List<MovieCommentModel> Comments { get; set; }
        public List<MovieRatingModel> Ratings { get; set; }

        public List<MovieLikesModel> Likes { get; set; }

        public int Views { get; set; }


    }
}
