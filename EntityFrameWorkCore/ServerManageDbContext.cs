using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameWorkCore
{
    public class ServerManageDbContext: DbContext
    {
        public ServerManageDbContext(DbContextOptions<ServerManageDbContext> options) : base(options)
        {

        }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<ServerList> ServerList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //UserRole关联配置
            builder.Entity<UserRole>()
              .HasKey(ur => new { ur.UserId});

            //RoleMenu关联配置
            builder.Entity<ServerList>()
              .HasKey(sl => new {  sl.ServerId});
   
        }
    }
}
