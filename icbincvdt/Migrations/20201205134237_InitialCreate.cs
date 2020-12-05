using Microsoft.EntityFrameworkCore.Migrations;

namespace icbincvdt.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EducationTitle = table.Column<string>(nullable: true),
                    EducationText = table.Column<string>(nullable: true),
                    EducationYearRange = table.Column<string>(nullable: true),
                    CVID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.EducationID);
                    table.ForeignKey(
                        name: "FK_Education_CV_CVID",
                        column: x => x.CVID,
                        principalTable: "CV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExperienceTitle = table.Column<string>(nullable: true),
                    ExperienceText = table.Column<string>(nullable: true),
                    ExperienceYearRange = table.Column<string>(nullable: true),
                    CVID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExperienceID);
                    table.ForeignKey(
                        name: "FK_Experience_CV_CVID",
                        column: x => x.CVID,
                        principalTable: "CV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    ReferenceID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReferenceName = table.Column<string>(nullable: true),
                    ReferencePhoneNumber = table.Column<int>(nullable: false),
                    CVID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.ReferenceID);
                    table.ForeignKey(
                        name: "FK_Reference_CV_CVID",
                        column: x => x.CVID,
                        principalTable: "CV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillTitle = table.Column<string>(nullable: true),
                    SkillText = table.Column<string>(nullable: true),
                    SkillRating = table.Column<int>(nullable: false),
                    CVID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_Skill_CV_CVID",
                        column: x => x.CVID,
                        principalTable: "CV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_CVID",
                table: "Education",
                column: "CVID");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_CVID",
                table: "Experience",
                column: "CVID");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_CVID",
                table: "Reference",
                column: "CVID");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CVID",
                table: "Skill",
                column: "CVID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "CV");
        }
    }
}
