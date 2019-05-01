using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQueue.Models;
using OnlineQueue.Services;

namespace OnlineQueue.Controllers
{
    public class QueueController : Controller
    {
        private readonly IQueueService _queue;
        public QueueController(IQueueService queue)
        {
            _queue =queue;
        }

        /// <summary>
        /// Список Очереди 
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            var queue = _queue.GetAll();
            return View(queue);
        }

        /// <summary>
        /// Получает страницу записи в очередь
        /// </summary>
        [HttpGet]
        public IActionResult Write()
        {
            return View();
        }

        /// <summary>
        /// записывает в очередь
        /// </summary>
        /// <param name="queue">очередь</param>
        public IActionResult Write(Queue queue)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _queue.Write(queue, "add");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Невозможно сохранить изменения. " +
                                   "Повторите попытку, и если проблема не устранена, " + "обратитесь к системному администратору.");
            }
            return View(queue);
        }

        /// <summary>
        /// Удаляет с очереди
        /// </summary>
        /// <param name="id">Идентификатор персонажа</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _queue.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}