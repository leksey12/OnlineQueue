using DAL_OnlineQueue.Services;
using DAL_OnlineQueue.Services.Imlementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_OnlineQueue.EFContext
{
    public static class DataLibraryCollectionExtentions
    {
        public static IServiceCollection AddDataLibraryCollection(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddEntityFrameworkNpgsql()
               .AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IQueueDataService, QueueDataService>();
            return services;
        }
    }
}