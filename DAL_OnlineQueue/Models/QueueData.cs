using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_OnlineQueue.Models
{
    /// <summary>
    /// Очередь сотрудников
    /// </summary>
    public class QueueData
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

        public UserData User { get; set; }
    }
}