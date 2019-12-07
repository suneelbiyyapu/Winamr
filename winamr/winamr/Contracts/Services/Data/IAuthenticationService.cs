﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using winamr.Models;

namespace winamr.Contracts.Services.Data
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName, string password);

        Task<AuthenticationResponse> Authenticate(string userName, string password);

        bool IsUserAuthenticated();
    }
}
