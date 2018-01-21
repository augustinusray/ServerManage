using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServerList",
                columns: table => new
                {
                    ServerId = table.Column<string>(nullable: false),
                    ServerAuthority = table.Column<int>(nullable: false),
                    ServerName = table.Column<string>(nullable: true),
                    ServerPass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerList", x => x.ServerId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserAuthority = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserPass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerList");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
