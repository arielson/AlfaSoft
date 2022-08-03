using AlfaSoft.Application.Applications;
using AlfaSoft.Application.Interfaces;
using AlfaSoft.Domain;
using AlfaSoft.Repository;
using AlfaSoft.Repository.Interfaces;
using AlfaSoft.Repository.Repositories;
using AlfaSoft.Service.Interfaces;
using AlfaSoft.Service.Services;
using AlfaSoft.Web.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AlfaSoft
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
            Settings.ConnectionString = Configuration["Connection:SqlServerConnectionString"];
            services.AddDbContext<SqlContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IUserApplication, UserApplication>();


            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactService, ContactService>();
            services.AddScoped<IContactApplication, ContactApplication>();

            services.AddHttpContextAccessor();
            services.AddSingleton<SessionHelper>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SqlContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            Web.Helpers.AppContext.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            InitializeDb.Initialize(context);
        }
    }
}
