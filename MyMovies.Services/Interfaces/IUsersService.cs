using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        User GetDetails(int userId);

        void UpdateUser(User user);
        void DeleteUser(int id);

        List<User> GetAllUsers();

        void IsAdmin(User user);
        bool ToggleAdminRole(int id);
    }
}
