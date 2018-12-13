using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations
{
    public partial class SaltPasswordEncrypted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Admin",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Admin");
        }
    }
}
