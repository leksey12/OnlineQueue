using DAL_OnlineQueue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_OnlineQueue.EFContext
{
   public class Initialization_micro
    {
        const int interval = 5;
        public static int number = 4;
        public int count = 2 * (60 / interval);
        public DateTime Today { get; set; }
        public IList<string> UserNames { get; set; }
        public int Microwave { get; set; }

        public Initialization_micro(int id)
        {
            Today = DateTime.Now.Date;
            Microwave = id;

            UserNames = new List<string>();
            for (int i = 0; i < count; i++)
                UserNames.Add("Свободно");
        }
        public Initialization_micro(int id, DateTime date) : this(id)
        {
            Today = date;
        }
        public static bool AviableFour(List<Initialization_micro> micro, UserData user)
        {
            int countOfThisUser = 0;
            if (user != null)
                micro.ForEach(stackDay =>
                {
                    if (stackDay.UserNames.Any(un => un.Equals(user.Name)))
                        countOfThisUser += stackDay.UserNames.Count(un => un == user.Name);
                });
            return (countOfThisUser >= 4) ? false : true;
        }

    }

    public static class Extentions
    {
        //Заполняем список очереди именами тех кто уже занял очередь.
        public static Initialization_micro SetUsers(this Initialization_micro micro, ApplicationDbContext db)
        {
            //все занятые сегодня места
            DateTime today = micro.Today;
            IEnumerable<QueueData> Fulled = db.Queues.Include(s => s.User)
                .Where(s => s.Date.Equals(today) && s.Microwave == micro.Microwave)
                .Select(s => s);
            //пишем имя пользователя в занятую ячейку очереди
            for (int i = 0; i < Fulled.Count(); i++)
            {
                int number = Fulled.ElementAt(i).Number;
                micro.UserNames[number - 1] = Fulled.ElementAt(i).User.Name;
            }
            return micro;
        }

    }

}