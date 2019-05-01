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
            return db.Queue.ToList();
        }

        public async Task Write(QueueData queue)
        {
            db.Queue.Add(queue);
            await db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var queue = await db.Queue.FindAsync(id);
            db.Queue.Remove(queue);
            await db.SaveChangesAsync();
        }
    }
}
