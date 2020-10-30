using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moonglade.Data.Migrations
{
    public partial class addlocalaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 32, nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 64, nullable: true),
                    LastLoginTimeUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastLoginIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreateOnUtc = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalAccount", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalAccount");
        }
    }
}
