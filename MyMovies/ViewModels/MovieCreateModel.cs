using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.ViewModels
{
    public class MovieCreateModel
    {

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter valid image url")]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 4)]
        public string Genre { get; set; }

    }
}
