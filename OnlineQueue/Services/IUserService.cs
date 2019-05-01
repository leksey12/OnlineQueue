using Microsoft.AspNetCore.Identity;
using OnlineQueue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQueue.Services
{
    /// <summary>
    /// Интерфейс работы с пользователями
    /// </summary>
    interface IUserService
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="pass">Пароль</param>
        Task<IdentityResult> Register(User user, string pass);

        /// <summary>
        /// Вход на сайт при регистрации
        /// </summary>
        /// <param name="user">Пользователь</param>
        Task SignIn(User user);

        /// <summary>
        /// Вход на сайт по паролю
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="pass">Пароль</param>
        /// <param name="rememberMe">Флаг запоминания на сайте</param>
        Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe);
    }
}
