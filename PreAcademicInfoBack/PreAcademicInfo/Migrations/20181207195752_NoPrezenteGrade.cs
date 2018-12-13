using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations
{
    public partial class NoPrezenteGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrezenteLab",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "PrezenteSeminar",
                table: "Grade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrezenteLab",
                table: "Grade",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrezenteSeminar",
                table: "Grade",
                nullable: false,
                defaultValue: 0);
        }
    }
}
