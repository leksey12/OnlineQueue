using BLL_OnlineQueue.Models;
using BLL_OnlineQueue.Services;
using Mapster;
using Microsoft.AspNetCore.Identity;
using OnlineQueue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQueue.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserBusinessService userData;

        public UserService(IUserBusinessService userData)
        {
            this.userData = userData;
        }

        public async Task<IdentityResult> Register(User user, string pass)
        {
            var baseUser = user.Adapt<UserBusiness>();
            return (await userData.Register(baseUser, pass)).Adapt<IdentityResult>();
        }

        public Task SignIn(User user)
        {
            var baseUser = user.Adapt<UserBusiness>();
            return userData.SignIn(baseUser);
        }

        public async Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe)
        {
            return (await userData.PasswordSignIn(email, pass, rememberMe)).Adapt<SignInResult>();
        }
    }
}
