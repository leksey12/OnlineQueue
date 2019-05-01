using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQueue.ViewModels
{
    /// <summary>
    /// Класс регистрации
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
       
        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Error Name")]
        public string Name { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Подтвержение пароля
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

    }
}