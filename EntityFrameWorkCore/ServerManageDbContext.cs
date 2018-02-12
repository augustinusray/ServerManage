using Domain.Entitys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameWorkCore
{
    public class ServerManageDbContext: IdentityDbContext<User>
    {
        public ServerManageDbContext(DbContextOptions<ServerManageDbContext> options) : base(options)
        {
        }

        public DbSet<ServerList> ServerList { get; set; }

        public DbSet<UserLoginLog> UserLoginLog { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //ServerList关联配置
            builder.Entity<ServerList>()
              .HasKey(sl => new {  sl.ServerId});

            //UserLoginLog关联配置
            builder.Entity<UserLoginLog>()
              .HasKey(sl => new { sl.Id });

        }
    }
}
