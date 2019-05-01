using DAL_OnlineQueue.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_OnlineQueue.EFContext
{
    public class ApplicationDbContext : IdentityDbContext<UserData>
    {
        public DbSet<QueueData> Queue { get; set; }
        public DbSet<UserData> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        /// <summary>
        /// Для миграции
        /// </summary>
        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseNpgsql(@"User ID = postgres;Password=aleksey;Server=localhost;Port=5432;Database=OnlineQueue;Integrated Security=true; Pooling=true;", b => b.MigrationsAssembly("DAL_OnlineQueue"));
                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }
    }
}