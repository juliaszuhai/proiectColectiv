using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations
{
    public partial class Cereri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrezenteLab",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "PrezenteSeminar",
                table: "Grade");

            migrationBuilder.AddColumn<string>(
                name: "DataNotei",
                table: "Grade",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProcentInnerType",
                table: "Grade",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProcentOuter",
                table: "Grade",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NumarLaboratoare",
                table: "Discipline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Adresa",
                table: "Admin",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNotei",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "ProcentInnerType",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "ProcentOuter",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "NumarLaboratoare",
                table: "Discipline");

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

            migrationBuilder.AlterColumn<int>(
                name: "Adresa",
                table: "Admin",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
