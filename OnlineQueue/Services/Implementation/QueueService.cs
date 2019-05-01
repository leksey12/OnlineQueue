using BLL_OnlineQueue.Models;
using BLL_OnlineQueue.Services;
using Mapster;
using OnlineQueue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQueue.Services.Implementation
{
    public class QueueService: IQueueService
    {
        private readonly IQueueBusinessService queueData;
        public QueueService(IQueueBusinessService queueData)
        {
            this.queueData = queueData;
        }

        public IEnumerable<Queue> GetAll()
        {
            return queueData.GetAll().Adapt<IEnumerable<Queue>>();
        }

        public async Task<int> Write(Queue queue, string operation)
        {
            var businessQueue = queue.Adapt<QueueBusiness>();
            await queueData.Write(businessQueue, operation);
            return businessQueue.Id;
        }

        public Task DeleteAsync(int id)
        {
            return queueData.DeleteAsync(id);
        }

    }
}
