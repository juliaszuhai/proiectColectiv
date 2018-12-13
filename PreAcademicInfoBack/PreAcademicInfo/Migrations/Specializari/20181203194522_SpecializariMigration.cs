using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations.Specializari
{
    public partial class SpecializariMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Adresa = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    NumarTelefon = table.Column<int>(maxLength: 14, nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Username);
                });

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

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    NumarTelefon = table.Column<int>(maxLength: 14, nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacultyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specializare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminUsername = table.Column<string>(nullable: true),
                    CuFrecventa = table.Column<bool>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Limba = table.Column<int>(nullable: false),
                    NumarSemestre = table.Column<int>(nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    TaxaPerCredit = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializare_Admin_AdminUsername",
                        column: x => x.AdminUsername,
                        principalTable: "Admin",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specializare_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Cod = table.Column<string>(nullable: false),
                    An = table.Column<int>(nullable: false),
                    Credite = table.Column<int>(nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Semestru = table.Column<int>(nullable: false),
                    SpecializareId = table.Column<int>(nullable: false),
                    TeacherUsername = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Cod);
                    table.ForeignKey(
                        name: "FK_Discipline_Specializare_SpecializareId",
                        column: x => x.SpecializareId,
                        principalTable: "Specializare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discipline_Teacher_TeacherUsername",
                        column: x => x.TeacherUsername,
                        principalTable: "Teacher",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_SpecializareId",
                table: "Discipline",
                column: "SpecializareId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_TeacherUsername",
                table: "Discipline",
                column: "TeacherUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Specializare_AdminUsername",
                table: "Specializare",
                column: "AdminUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Specializare_DepartmentId",
                table: "Specializare",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Specializare");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
