using BLL_OnlineQueue.Models;
using DAL_OnlineQueue.Models;
using DAL_OnlineQueue.Services;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL_OnlineQueue.Services.Implementation
{
    public class QueueBusinessService : IQueueBusinessService
    {
        private readonly IQueueDataService queueServices;
        public QueueBusinessService(IQueueDataService queueServices)
        {
            this.queueServices = queueServices;
        }

        public IEnumerable<QueueBusiness> GetAll()
        {
            var queueDto = queueServices.GetAll();
            var queue = new List<QueueBusiness>();
            foreach (var el in queueDto)
            {
                var personages = el.Adapt<QueueBusiness>();
                queue.Add(personages);
            }
            return queue;
        }
        public async Task Write(QueueBusiness queue, string operation)
        {

            var queueDto = queue.Adapt<QueueData>();
            queueDto.Id = queue.Id;
            switch (operation)
            {
                case "add":
                    await queueServices.Write(queueDto);
                    break;
            }
        }
        public Task DeleteAsync(int id)
        {
            return queueServices.DeleteAsync(id);
        }
    }
}