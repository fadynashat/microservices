﻿using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace FADY.Services.IdentityServer.API.Services
{
    public interface ILoginService<T>
    {
        Task<bool> ValidateCredentials(T user, string password);

        Task<T> FindByUsername(string user);

        Task SignIn(T user);

        Task SignInAsync(T user, AuthenticationProperties properties, string authenticationMethod = null);
    }
}
