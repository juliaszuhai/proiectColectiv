using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations
{
    public partial class Disciplina_Specializare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinalGrade",
                table: "Grade",
                newName: "GradeValue");

            migrationBuilder.AddColumn<int>(
                name: "Semestru",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecializareId",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_SpecializareId",
                table: "Discipline",
                column: "SpecializareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Specializare_SpecializareId",
                table: "Discipline",
                column: "SpecializareId",
                principalTable: "Specializare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Specializare_SpecializareId",
                table: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_SpecializareId",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "Semestru",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "SpecializareId",
                table: "Discipline");

            migrationBuilder.RenameColumn(
                name: "GradeValue",
                table: "Grade",
                newName: "FinalGrade");
        }
    }
}
