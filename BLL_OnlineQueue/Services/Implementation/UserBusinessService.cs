using BLL_OnlineQueue.Models;
using DAL_OnlineQueue.Models;
using DAL_OnlineQueue.Services;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL_OnlineQueue.Services.Implementation
{
    public class UserBusinessService : IUserBusinessService
    {
        private readonly IUserDataService userServices;

        public UserBusinessService(IUserDataService userServices)
        {
            this.userServices = userServices;
        }

        public async Task<IdentityResult> Register(UserBusiness user, string pass)
        {
            var userData = user.Adapt<UserData>();
            return await userServices.Register(userData, pass);
        }

        public Task SignIn(UserBusiness user)
        {
            var userData = user.Adapt<UserData>();
            return userServices.SignIn(userData);
        }

        public async Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe)
        {
            return await userServices.PasswordSignIn(email, pass, rememberMe);
        }
    }
}
