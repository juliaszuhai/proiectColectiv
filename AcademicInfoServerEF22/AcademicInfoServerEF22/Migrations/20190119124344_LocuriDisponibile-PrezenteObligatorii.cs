using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademicInfoServerEF22.Migrations
{
    public partial class LocuriDisponibilePrezenteObligatorii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocuriDisponibile",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequiredLabAttendance",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequiredSeminaryAttendance",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocuriDisponibile",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "RequiredLabAttendance",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "RequiredSeminaryAttendance",
                table: "Discipline");
        }
    }
}
