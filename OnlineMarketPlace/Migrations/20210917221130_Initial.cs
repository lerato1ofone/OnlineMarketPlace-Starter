using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMarketPlace.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    UserRole = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "UserRole" },
                values: new object[,]
                {
                    { new Guid("f3c88bf1-cf94-4aad-8d60-36caa4d83992"), "admin@admin.com", "Admin", "Area", "$2a$10$BiKw/LkpvhHWsEyFw5gcR.Tv/EmLe2egNrmv2tQ3ZS8I79ZGDNkyK", 0 },
                    { new Guid("c181f9ed-945c-4cfa-a4d0-805c71c1da5c"), "msmith@customer.com", "Mason", "Smith", "$2a$10$UaEcyvvOVavyNf0Sb10ZGukvVaX02Mf7GJNIqVff8fnvwBqhp.kAq", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
