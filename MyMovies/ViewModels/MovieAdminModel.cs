using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieAdminModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        public DateTime Date { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
