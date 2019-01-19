using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademicInfoServerEF22.Migrations
{
    public partial class Attendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendanceLab",
                table: "GradeToDiscipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttendanceSeminary",
                table: "GradeToDiscipline",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendanceLab",
                table: "GradeToDiscipline");

            migrationBuilder.DropColumn(
                name: "AttendanceSeminary",
                table: "GradeToDiscipline");
        }
    }
}
