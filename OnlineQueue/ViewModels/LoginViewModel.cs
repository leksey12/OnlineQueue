using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQueue.ViewModels
{
    /// Класс Входа
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Флаг запоминания на сайте
        /// </summary>
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Строка возврата
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
