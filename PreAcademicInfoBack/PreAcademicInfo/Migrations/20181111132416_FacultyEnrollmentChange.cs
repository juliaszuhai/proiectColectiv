using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations
{
    public partial class FacultyEnrollmentChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacultyEnroll_Student_StudentUsername",
                table: "FacultyEnroll");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_GroupId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_FacultyEnroll_StudentUsername",
                table: "FacultyEnroll");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentUsername",
                table: "FacultyEnroll");

            migrationBuilder.RenameColumn(
                name: "NumeGrupa",
                table: "Group",
                newName: "GroupName");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "FacultyEnroll",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Department",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    NumeUniveristate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacultyEnroll_StudentId",
                table: "FacultyEnroll",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyEnroll_Student_StudentId",
                table: "FacultyEnroll",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultyEnroll_Student_StudentId",
                table: "FacultyEnroll");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropIndex(
                name: "IX_FacultyEnroll_StudentId",
                table: "FacultyEnroll");

            migrationBuilder.DropIndex(
                name: "IX_Department_FacultyId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "FacultyEnroll");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Group",
                newName: "NumeGrupa");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentUsername",
                table: "FacultyEnroll",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupId",
                table: "Student",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyEnroll_StudentUsername",
                table: "FacultyEnroll",
                column: "StudentUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyEnroll_Student_StudentUsername",
                table: "FacultyEnroll",
                column: "StudentUsername",
                principalTable: "Student",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
