using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieSidebarModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateCreated { get; set; }

        public int Views { get; set; }
    }
}
