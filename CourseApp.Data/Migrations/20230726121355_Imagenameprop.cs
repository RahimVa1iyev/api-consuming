using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApp.Data.Migrations
{
    public partial class Imagenameprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Students");
        }
    }
}
