using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IAuthService
    {
        bool SignIn(string username, string password,bool IsPersistent, HttpContext httpContext);

        void SignOut(HttpContext httpContext);
    }
}
