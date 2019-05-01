using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL_OnlineQueue.Models
{
    /// <summary>
    /// Очередь сотрудников
    /// </summary>
    public class QueueBusiness
    {
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

        public UserBusiness User { get; set; }
    }
}