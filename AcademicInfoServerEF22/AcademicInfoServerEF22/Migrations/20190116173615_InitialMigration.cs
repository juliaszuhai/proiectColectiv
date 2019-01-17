using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademicInfoServerEF22.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    NumarTelefon = table.Column<string>(maxLength: 20, nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    Adresa = table.Column<string>(nullable: false)
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
                    NumeUniveristate = table.Column<string>(nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Adresa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    NumarTelefon = table.Column<string>(maxLength: 20, nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    NumarMatricol = table.Column<int>(nullable: false),
                    CNP = table.Column<string>(nullable: false),
                    InitialaParinte = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Generatie = table.Column<string>(nullable: false),
                    An = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    NumarTelefon = table.Column<string>(maxLength: 20, nullable: false),
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
                    Name = table.Column<string>(nullable: false),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specializare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Limba = table.Column<int>(nullable: false),
                    NumarSemestre = table.Column<int>(nullable: false),
                    TaxaPerCredit = table.Column<double>(nullable: false),
                    CuFrecventa = table.Column<bool>(nullable: false),
                    AdminUsername = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Type = table.Column<int>(nullable: false),
                    SpecializareId = table.Column<int>(nullable: false),
                    Cod = table.Column<string>(nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Credite = table.Column<int>(nullable: false),
                    An = table.Column<int>(nullable: false),
                    Semestru = table.Column<int>(nullable: false),
                    TeacherUsername = table.Column<string>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacultyEnroll",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecializareId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
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
                name: "GradeToDiscipline",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisciplineCod = table.Column<string>(nullable: false),
                    StudentUsername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeToDiscipline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeToDiscipline_Discipline_DisciplineCod",
                        column: x => x.DisciplineCod,
                        principalTable: "Discipline",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeToDiscipline_Student_StudentUsername",
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
                    GradeValue = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ProcentInnerType = table.Column<double>(nullable: false),
                    ProcentOuter = table.Column<double>(nullable: false),
                    DataNotei = table.Column<string>(nullable: true),
                    GradesToDisciplineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_GradeToDiscipline_GradesToDisciplineId",
                        column: x => x.GradesToDisciplineId,
                        principalTable: "GradeToDiscipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Grade_GradesToDisciplineId",
                table: "Grade",
                column: "GradesToDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeToDiscipline_DisciplineCod",
                table: "GradeToDiscipline",
                column: "DisciplineCod");

            migrationBuilder.CreateIndex(
                name: "IX_GradeToDiscipline_StudentUsername",
                table: "GradeToDiscipline",
                column: "StudentUsername");

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
                name: "FacultyEnroll");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "GradeToDiscipline");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Student");

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
