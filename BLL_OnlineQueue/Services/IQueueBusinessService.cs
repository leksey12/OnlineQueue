using BLL_OnlineQueue.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL_OnlineQueue.Services
{
    /// <summary>
    /// Интерфейс работы с очередью
    /// </summary>
    public interface IQueueBusinessService
    {
        /// <summary>
        /// Список очереди
        /// </summary>
        /// <returns></returns>
        IEnumerable<QueueBusiness> GetAll();

        /// <summary>
        /// Запись в очередь
        /// </summary>
        /// <param name="queue"></param>
        Task Write(QueueBusiness queue, string operration);

        /// <summary>
        /// Выписаться с очереди
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task DeleteAsync(int id);
    }
}
