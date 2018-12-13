using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations
{
    public partial class ProcentajNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
