using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using MyMovies.Models;
using MyMovies.Common.Exceptions;

namespace MyMovies.Services
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User GetDetails(string userId)
        {
            return _usersRepository.GetById(int.Parse(userId));
        }

        public User GetDetails(int userId)
        {
            return _usersRepository.GetById(userId);
        }

        public void UpdateUser(User user)
        {
            var user_update = _usersRepository.GetById(user.Id);
            if (user_update != null)
            {
                user_update.Id = user.Id;
                user_update.Email = user.Email;
                user_update.Address = user.Address;

                _usersRepository.UpdateUser(user_update);
            }
            else
            {
                throw new NotFoundException($"The movie with id {user_update.Id} was not found");
            }
        }
    }
}
