

using System;

namespace MyMovies.ViewModels
{
    public class UserAdminModel
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
