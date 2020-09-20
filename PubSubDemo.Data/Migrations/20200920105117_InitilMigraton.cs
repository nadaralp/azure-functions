using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PubSubDemo.Data.Migrations
{
    public partial class InitilMigraton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    age = table.Column<int>(nullable: false),
                    register_date = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 9, 20, 13, 51, 17, 466, DateTimeKind.Local).AddTicks(9957))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
