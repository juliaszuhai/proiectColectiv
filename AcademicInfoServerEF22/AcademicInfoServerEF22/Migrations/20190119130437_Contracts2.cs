using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademicInfoServerEF22.Migrations
{
    public partial class Contracts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentUsername = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Student_StudentUsername",
                        column: x => x.StudentUsername,
                        principalTable: "Student",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractToDiscipline",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisciplineCod = table.Column<string>(nullable: false),
                    ContractId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractToDiscipline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractToDiscipline_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractToDiscipline_Discipline_DisciplineCod",
                        column: x => x.DisciplineCod,
                        principalTable: "Discipline",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_StudentUsername",
                table: "Contracts",
                column: "StudentUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ContractToDiscipline_ContractId",
                table: "ContractToDiscipline",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractToDiscipline_DisciplineCod",
                table: "ContractToDiscipline",
                column: "DisciplineCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractToDiscipline");

            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
