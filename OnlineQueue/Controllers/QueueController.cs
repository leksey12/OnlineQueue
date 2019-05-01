using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_OnlineQueue.EFContext;
using DAL_OnlineQueue.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;


namespace OnlineQueue.Controllers
{
    public class QueueController : Controller
    {
        private ApplicationDbContext db;
        DateTime today = DateTime.Now.Date;
        private readonly IStringLocalizer<QueueController> _localizer;
        private readonly IStringLocalizer<SharedResources> _sharedLocalizer;

        public QueueController(ApplicationDbContext context, IStringLocalizer<QueueController> localizer,
                   IStringLocalizer<SharedResources> sharedLocalizer)
        {
            db = context;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }
        /// <summary>
        /// просмотр очереди/запись.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult Index(string strDate = "")
        {
            //парсим входную дату
            if (!string.IsNullOrWhiteSpace(strDate))
                DateTime.TryParse(strDate, out today);

            // проверяем удаленность даты на доступность
            if (today > DateTime.Now.AddDays(1)) return Content("" + today.ToString("dd-MM-yyyy") + "");

            //очереди ко всем микроволновкам
            List<Initialization_micro> stackTodays = new List<Initialization_micro>();
            for (int i = 0; i < Initialization_micro.number; i++)
            {
                stackTodays.Add(new Initialization_micro(i, today));
            }

            //проверяем есть ли уже на сегодня занятые места
            stackTodays.ForEach(stackToday =>
            {
                if (db.Queues.Any(s => s.Date.Equals(stackToday.Today)))
                {
                    //заменяем текущую очередь
                    stackToday = stackToday.SetUsers(db);

                }
            });

            //не более 4х раз за день
            UserData user = db.Users.FirstOrDefault(u => u.Name == User.Identity.Name);

            if (! Initialization_micro.AviableFour(stackTodays, user)) return Content("На сегодня хватит, приходите завтра");

            if (user != null)
                ViewData["UserName"] = user.Name;
            //отправляем список очередей
            return View(stackTodays);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(QueueData queue)
        {
            //устанавливаем в объект записи UserId из Куков
            queue.UserId = db.Users.FirstOrDefault(u => u.Name == User.Identity.Name).Id;

            if (ModelState.IsValid)
            {
                // проверяем что еще не заняли
                if (!db.Queues.Any(s => s.Microwave == queue.Microwave && s.Date == queue.Date && s.Number == queue.Number))
                {
                    db.Queues.Add(queue);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Queue");
                }
                else return Content("Уже занято");
            }
            return Content("not valid");
        }

    }
}
