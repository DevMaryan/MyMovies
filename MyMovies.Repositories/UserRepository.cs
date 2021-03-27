using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System.Linq;

namespace MyMovies.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly MoviesDbContext _context;

        public UserRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }
        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void UpdateUser(User user)
        {

             _context.Users.Update(user);
             _context.SaveChanges();
          
        }
    }
}
