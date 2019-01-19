using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademicInfoServerEF22.Migrations
{
    public partial class TeacherURLAndDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureURL",
                table: "Teacher",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "PictureURL",
                table: "Teacher");
        }
    }
}
