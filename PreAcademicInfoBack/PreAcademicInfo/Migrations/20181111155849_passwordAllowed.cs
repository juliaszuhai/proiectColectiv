using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations
{
    public partial class passwordAllowed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Admin",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Admin");
        }
    }
}
