using DAL_OnlineQueue.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL_OnlineQueue.Services
{
    /// <summary>
    /// Интерфейс работы с очередью
    /// </summary>
    public interface IQueueDataService
    {
        /// <summary>
        /// Список очереди
        /// </summary>
        /// <returns></returns>
        IEnumerable<QueueData> GetAll();

        /// <summary>
        /// Запись в очередь
        /// </summary>
        /// <param name="queue"></param>
        Task Write(QueueData queue);

        /// <summary>
        /// Выписаться с очереди
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task DeleteAsync(int id);

    }
}