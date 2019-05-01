using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQueue.Models
{
    /// <summary>
    /// Очередь Сотрудников
    /// </summary>
    public class Queue
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя 
        /// </summary>
        /// [Required(ErrorMessage = "Поле должно быть заполнено")]
        [RegularExpression(@"[а-яa-zA-ZА-Я0-9]*", ErrorMessage = "Некорректное имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [RegularExpression(@"[а-яa-zA-ZА-Я0-9]*", ErrorMessage = "Некорректная фамилия")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        [Required(ErrorMessage = "Данное поле должно быть заполнено")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Должность следует ввести от 5-20 символов.")]
        [Display(Name = "Должность")]
        public string Position { get; set; }

    }
}
