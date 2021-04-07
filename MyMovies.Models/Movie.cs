using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Models
{
    public class Movie
    {
        [Key]//Not neccessary
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:50,MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage ="Enter valid image url")]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 4)]
        public string Genre { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public DateTime? DateModified { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Rating> Ratings { get; set; }

        public List<Like> Likes { get; set; }

        public int Views { get; set; }

    }
}
