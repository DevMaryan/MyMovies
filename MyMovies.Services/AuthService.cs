using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _userRepository;

        public AuthService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool SignIn(string username, string password,bool IsPersistent, HttpContext httpContext)
        {

            var response = false;
            var user = _userRepository.GetByUsername(username);

            if(user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("Address", user.Address),
                    new Claim("Email", user.Email),
                    new Claim("IsAdmin", user.IsAdmin.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var authProps = new AuthenticationProperties() { IsPersistent = IsPersistent };

                Task.Run(() => httpContext.SignInAsync(principal)).GetAwaiter().GetResult();
                response = true;
            }
            else
            {
                response = false;
            }
            return response;
        }

        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }

        public bool SignUp(User user)
        {
            var response = false;
            var exist_user = _userRepository.CheckIfExists(user.Username, user.Email);

            if (exist_user)
            {
                response = false;
                return response;
            }
            else
            {
                var newUser = new User()
                {
                    Username = user.Username,
                    Email = user.Email,
                    Address = user.Address,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                    DateCreated = DateTime.Now,
                };
                _userRepository.Add(newUser);
                response = true;
            }

            return response;

        }
    }
}
