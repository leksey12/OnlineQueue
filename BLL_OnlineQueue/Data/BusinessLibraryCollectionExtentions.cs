using BLL_OnlineQueue.Services;
using BLL_OnlineQueue.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_OnlineQueue.Data
{
    public static class BusinessLibraryCollectionExtentions
    {
        public static IServiceCollection AddBusinessLibraryCollection(this IServiceCollection services)
        {
            services.AddScoped<IQueueBusinessService, QueueBusinessService>();
            services.AddScoped<IUserBusinessService, UserBusinessService>();

            return services;
        }
    }
}