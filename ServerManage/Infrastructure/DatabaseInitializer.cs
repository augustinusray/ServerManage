using Domain.Entitys;
using EntityFrameWorkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ServerManage.Infrastructure
{
    public class DatabaseInitializer
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            var context = applicationBuilder.ApplicationServices.GetRequiredService<ServerManageDbContext>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                context.Users.Add(new User() {
                    UserName = "admin",
                    PasswordHash = "AQAAAAEAACcQAAAAEIt0a9G7LLXmIOWTkH6YP+/8LFRcQ0m9Oga70KrlKUBxVL4czu+iHhj7NuZJREJA/A==",
                    UserAuthority = 10 ,
                    Description ="超级管理员"});
                context.SaveChanges();
            }
        }
    }
}
