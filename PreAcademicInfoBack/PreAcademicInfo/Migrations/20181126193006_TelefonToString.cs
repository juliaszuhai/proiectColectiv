using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations
{
    public partial class TelefonToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumarTelefon",
                table: "Teacher",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "NumarTelefon",
                table: "Student",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "NumarTelefon",
                table: "Admin",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumarTelefon",
                table: "Teacher",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "NumarTelefon",
                table: "Student",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "NumarTelefon",
                table: "Admin",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
