using DAL_OnlineQueue.EFContext;
using DAL_OnlineQueue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_OnlineQueue.Services.Imlementation
{
    public class QueueDataService : IQueueDataService
    {
        private ApplicationDbContext db;
        public QueueDataService(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<QueueData> GetAll()
        {
            return db.Queues.ToList();
        }

        public async Task Write(QueueData queue)
        {
            db.Queues.Add(queue);
            await db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var queue = await db.Queues.FindAsync(id);
            db.Queues.Remove(queue);
            await db.SaveChangesAsync();
        }
    }
}
