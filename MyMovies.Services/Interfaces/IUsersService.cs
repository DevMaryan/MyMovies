using MyMovies.Models;

namespace MyMovies.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        User GetDetails(int userId);

        void UpdateUser(User user);
    }
}
