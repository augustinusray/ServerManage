using Application;
using Application.Iservices;
using AutoMapper;
using Domain.Entitys;
using Domain.IRepositorys;
using EntityFrameWorkCore;
using EntityFrameWorkCore.Repositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServerManage.Filters;
using ServerManage.Infrastructure;
using ServerManage.Logger;
using System;

namespace ServerManage
{
    public class Startup
    {
        private MapperConfiguration _mapperConfiguration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //mapper
            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
            //数据库连接
            string conn = Configuration.GetConnectionString("ServerManageConnection");
            services.AddDbContext<ServerManageDbContext>(options => 
            options.UseSqlServer(conn,b=> b.MigrationsAssembly("ServerManage")));

            //Identity 注册
            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ServerManageDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 3;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Name = "ServerManageCookie";
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Home/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Home/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Home/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            //服务注册
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IServerAdminService, ServerAdminService>();
            services.AddScoped<IUserAdminService, UserAdminService>();

            //仓储注册
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IServerListRepository, ServerListRepository>();
            services.AddScoped<IUserLoginLogRepository, UserLoginLogRepository>();

            //services.AddMvc(option => { option.Filters.Add(typeof(CustomAuthorizeFilter)); });  // 全局过滤

            services.AddMvc(option => { option.Filters.Add(typeof(GlobalExceptionFilter)); });
            //services.AddMvc();
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
            //初始管理员账号
            DatabaseInitializer.Initialize(app);

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
