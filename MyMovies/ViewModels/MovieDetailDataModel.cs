using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieDetailDataModel
    {
        public MovieDetailModel  MovieDetail { get; set; } = new MovieDetailModel();

        public MovieSidebarDataModel SidebarData { get; set; } = new MovieSidebarDataModel();

        public MovieLikesModel MovieLikes { get; set; } = new MovieLikesModel();
    }
}
