using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_OnlineQueue.Models
{
    /// <summary>
    /// Очередь сотрудников
    /// </summary>
    public class QueueBusiness
    {
        /// <summary>
        /// Идентификатор 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }
    }
}