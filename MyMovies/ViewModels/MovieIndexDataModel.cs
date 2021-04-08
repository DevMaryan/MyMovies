using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieIndexDataModel
    {
        public List<MovieIndexModel> IndexModels { get; set; }

        public List<MovieRatingModel> Ratings { get; set; }

        public List<MovieLikesModel> Likes { get; set; }
        public MovieSidebarDataModel SidebarData { get; set; } = new MovieSidebarDataModel(); // It will create empty list, at least return it will not be null object
    }
}
