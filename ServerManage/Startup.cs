using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Iservices;
using Domain.IRepositorys;
using EntityFrameWorkCore;
using EntityFrameWorkCore.Repositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerManage.Filters;

namespace ServerManage
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
            //services.AddMvc(option => { option.Filters.Add(typeof(CustomAuthorizeFilter)); });  // 全局过滤
            services.AddMvc();
            string conn = Configuration.GetConnectionString("ServerManageConnection");
            services.AddDbContext<ServerManageDbContext>(options => 
            options.UseSqlServer(conn));

            //仓储注册
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication(); //启用身份验证

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
