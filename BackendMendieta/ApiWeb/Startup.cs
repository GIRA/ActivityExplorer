using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using System.Net;
using AccessData;
using Model;
using Microsoft.EntityFrameworkCore;
using Login.Data;
using Microsoft.AspNetCore.Identity;

namespace ApiWeb
{
    public class Startup
    {

        readonly string PolicyCors = "PolicyCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("PolicyCors",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

                services.AddMvcCore()
                   .AddViews();
            });

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                   Configuration.GetConnectionString("MendietaBd")));

            services.AddDbContext<CAETIContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("MendietaBd")));
            services.AddIdentity<SystemUser, SystemUserRole>(config =>
            {
                config.Password.RequireDigit = true;
                config.Password.RequireUppercase = true;
                config.Password.RequiredLength = 8;
                config.Password.RequireNonAlphanumeric = false;
            })
             .AddEntityFrameworkStores<CAETIContext>()
             .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(config =>
            {
                config.Password.RequireDigit = true;
                config.Password.RequireUppercase = true;
                config.Password.RequiredLength = 8;
                config.Password.RequireNonAlphanumeric = false;

            });

            services.AddControllersWithViews();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCors(options=> options.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            });
        }
    }


}
