using Domain.Entitys;
using EntityFrameWorkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ServerManage.Infrastructure
{
    public class DatabaseInitializer
    {  
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                var context = serviceScope.ServiceProvider.GetService<ServerManageDbContext>();

                if (!context.Users.Any())
                {
                    userManager.CreateAsync(new User {
                        UserName="admin",
                        UserAuthority=10,
                        Description="超级管理员"
                    }, "12345678");
                }
            }
        }
    }
}
