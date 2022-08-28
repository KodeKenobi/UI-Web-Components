using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolicyManagementSystem.Data;
using PolicyManagementDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolicyManagementDataAccess.Repositories;
using PolicyManagementDataAccess.Context;
using PolicyManagementDataAccess.Helpers;
using AutoMapper;
using PolicyManagementDataAccess.Service;
using PolicyManagementMailer.Models;

namespace PolicyManagementSystem
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
            services.AddControllersWithViews();
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddDbContext<BrkBaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DataConnection"));
                });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IMemberApplicationRepository, MemberApplicationRepository>();
            services.AddScoped<IPolicyApplicationRepository, PolicyApplicationRepository>();
            services.AddScoped<IPolicyManagementRepository, PolicyManagementRepository>();
            services.AddScoped<IClientEngagementRepository, ClientEngagementRepository>();
            services.AddScoped<IEmailService, EmailService>();
            //  services.AddScoped<>


            services.Configure<SMTPConfigModel>(Configuration.GetSection("SMTPConfig"));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BrkBaseContext>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
