﻿// <auto-generated />
using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EntityFrameWorkCore.Migrations
{
    [DbContext(typeof(ServerManageDbContext))]
    partial class ServerManageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entitys.ServerList", b =>
                {
                    b.Property<string>("ServerId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<int>("ServerAuthority");

                    b.Property<string>("ServerName")
                        .HasMaxLength(50);

                    b.Property<string>("ServerPass")
                        .HasMaxLength(128);

                    b.HasKey("ServerId");

                    b.ToTable("ServerList");
                });

            modelBuilder.Entity("Domain.Entitys.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<int>("UserAuthority");

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.Property<string>("UserPass")
                        .HasMaxLength(128);

                    b.HasKey("UserId");

                    b.ToTable("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
