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
        /// 
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Microwave { get; set; }

        [Required]
        public int Number { get; set; }
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
