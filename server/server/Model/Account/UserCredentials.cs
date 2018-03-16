﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Model.Account
{
    public class UserCredentials
    {
        public UserCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}