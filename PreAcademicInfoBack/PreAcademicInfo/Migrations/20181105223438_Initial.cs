using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PreAcademicInfo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Adresa = table.Column<int>(nullable: false),
                    Email = table.Column<int>(nullable: false),
                    NumarTelefon = table.Column<int>(maxLength: 14, nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeGrupa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<int>(nullable: false),
                    NumarTelefon = table.Column<int>(maxLength: 14, nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Username);
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
                name: "Student",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    An = table.Column<string>(nullable: false),
                    Email = table.Column<int>(nullable: false),
                    Generatie = table.Column<string>(nullable: false),
                    GroupId = table.Column<int>(nullable: true),
                    InitialaParinte = table.Column<string>(nullable: false),
                    NumarTelefon = table.Column<int>(maxLength: 14, nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Student_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Cod = table.Column<string>(nullable: false),
                    An = table.Column<int>(nullable: false),
                    Credite = table.Column<int>(nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    TeacherUsername = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Cod);
                    table.ForeignKey(
                        name: "FK_Discipline_Teacher_TeacherUsername",
                        column: x => x.TeacherUsername,
                        principalTable: "Teacher",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyEnroll",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false),
                    SpecializareId = table.Column<int>(nullable: false),
                    StudentUsername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyEnroll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyEnroll_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyEnroll_Specializare_SpecializareId",
                        column: x => x.SpecializareId,
                        principalTable: "Specializare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyEnroll_Student_StudentUsername",
                        column: x => x.StudentUsername,
                        principalTable: "Student",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradesToDiscipline",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisciplineCod = table.Column<string>(nullable: false),
                    StudentUsername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradesToDiscipline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradesToDiscipline_Discipline_DisciplineCod",
                        column: x => x.DisciplineCod,
                        principalTable: "Discipline",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradesToDiscipline_Student_StudentUsername",
                        column: x => x.StudentUsername,
                        principalTable: "Student",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisciplineCod = table.Column<string>(nullable: false),
                    FinalGrade = table.Column<double>(nullable: false),
                    GradesToDisciplineId = table.Column<int>(nullable: true),
                    PrezenteLab = table.Column<int>(nullable: false),
                    PrezenteSeminar = table.Column<int>(nullable: false),
                    StudentUsername = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Discipline_DisciplineCod",
                        column: x => x.DisciplineCod,
                        principalTable: "Discipline",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grade_GradesToDiscipline_GradesToDisciplineId",
                        column: x => x.GradesToDisciplineId,
                        principalTable: "GradesToDiscipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_Student_StudentUsername",
                        column: x => x.StudentUsername,
                        principalTable: "Student",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_TeacherUsername",
                table: "Discipline",
                column: "TeacherUsername");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyEnroll_GroupId",
                table: "FacultyEnroll",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyEnroll_SpecializareId",
                table: "FacultyEnroll",
                column: "SpecializareId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyEnroll_StudentUsername",
                table: "FacultyEnroll",
                column: "StudentUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_DisciplineCod",
                table: "Grade",
                column: "DisciplineCod");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_GradesToDisciplineId",
                table: "Grade",
                column: "GradesToDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentUsername",
                table: "Grade",
                column: "StudentUsername");

            migrationBuilder.CreateIndex(
                name: "IX_GradesToDiscipline_DisciplineCod",
                table: "GradesToDiscipline",
                column: "DisciplineCod");

            migrationBuilder.CreateIndex(
                name: "IX_GradesToDiscipline_StudentUsername",
                table: "GradesToDiscipline",
                column: "StudentUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Specializare_AdminUsername",
                table: "Specializare",
                column: "AdminUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Specializare_DepartmentId",
                table: "Specializare",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupId",
                table: "Student",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyEnroll");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Specializare");

            migrationBuilder.DropTable(
                name: "GradesToDiscipline");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
