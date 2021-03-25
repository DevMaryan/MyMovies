using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.Models;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
    }
}
