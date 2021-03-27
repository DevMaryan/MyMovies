using System.ComponentModel.DataAnnotations;

namespace MyMovies.ViewModels
{
    public class UserUpdateModel
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
