using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Classes;
using Portal.Application.Students;
using Portal.Persistance;

namespace Portal.Web
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PortalDbContext>(options =>
             options.UseSqlite("Data Source=app.sqlite"));


            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<PortalDbContext>();

            services.AddAutoMapper();

            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ClassValidator, ClassValidator>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
