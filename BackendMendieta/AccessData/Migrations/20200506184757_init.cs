using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    AgeMin = table.Column<int>(nullable: false),
                    AgeMax = table.Column<int>(nullable: false),
                    ShortDescp = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Files = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Naps = table.Column<string>(nullable: true),
                    PublishingDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");
        }
    }
}
