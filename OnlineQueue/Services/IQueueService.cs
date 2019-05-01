using OnlineQueue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQueue.Services
{
    /// <summary>
    /// Интерфейс работы с очередью
    /// </summary>
    public interface IQueueService
    {
        /// <summary>
        /// Список очереди
        /// </summary>
        /// <returns></returns>
        IEnumerable<Queue> GetAll();

        /// <summary>
        /// Запись в очередь
        /// </summary>
        /// <param name="queue"></param>
        Task<int> Write(Queue queue, string operation);

        /// <summary>
        /// Выписаться с очереди
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task DeleteAsync(int id);

    }
}