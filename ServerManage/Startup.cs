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
using Microsoft.Extensions.Logging;
using ServerManage.Filters;
using ServerManage.Logger;

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

            services.AddMvc(option => { option.Filters.Add(typeof(GlobalExceptionFilter)); });
            //services.AddMvc();
            string conn = Configuration.GetConnectionString("ServerManageConnection");
            services.AddDbContext<ServerManageDbContext>(options => 
            options.UseSqlServer(conn));

            //服务注册
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IServerAdminService, ServerAdminService>();

            //仓储注册
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IServerListRepository, ServerListRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //日志
            loggerFactory.AddLog4Net();
            loggerFactory.AddConsole();
            loggerFactory.AddDebug(Microsoft.Extensions.Logging.LogLevel.Debug);
            loggerFactory.AddEventSourceLogger();

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
