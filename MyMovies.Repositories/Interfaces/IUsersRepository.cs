using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.Models;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);

        User GetById(int userId);
        void UpdateUser(User user);
    }
}
