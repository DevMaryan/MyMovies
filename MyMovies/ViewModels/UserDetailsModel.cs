﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class UserDetailsModel
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
