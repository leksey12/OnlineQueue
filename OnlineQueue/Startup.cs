using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL_OnlineQueue.Data;
using DAL_OnlineQueue.EFContext;
using DAL_OnlineQueue.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineQueue.Services;
using OnlineQueue.Services.Implementation;

namespace OnlineQueue
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddMvc();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql(connection, b => b.MigrationsAssembly("DAL_OnlineQueue")));
            //зарегистрировал 
            services.AddScoped<IQueueService, QueueService>();
            services.AddScoped<IUserService, UserService>();
            services.AddDataLibraryCollection(Configuration);
            services.AddBusinessLibraryCollection();
            services.AddIdentity<UserData, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
