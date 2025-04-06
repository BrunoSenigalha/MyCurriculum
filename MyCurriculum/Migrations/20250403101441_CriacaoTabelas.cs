using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCurriculum.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "curriculum",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    picture = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    genders = table.Column<int>(type: "int", nullable: false),
                    professional_goals = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    linkedIn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curriculum", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zip_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    curriculum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_curriculum_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TypeCourse = table.Column<int>(type: "int", nullable: true),
                    curriculum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_courses_curriculum_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "formations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    institution = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    degree = table.Column<int>(type: "int", nullable: false),
                    types_formations = table.Column<int>(type: "int", nullable: false),
                    status_formation = table.Column<int>(type: "int", nullable: false),
                    studying = table.Column<bool>(type: "bit", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    curriculum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formations", x => x.id);
                    table.ForeignKey(
                        name: "FK_formations_curriculum_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    conversation_level = table.Column<int>(type: "int", nullable: true),
                    comprehension_level = table.Column<int>(type: "int", nullable: true),
                    writing_level = table.Column<int>(type: "int", nullable: true),
                    curriculum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.id);
                    table.ForeignKey(
                        name: "FK_languages_curriculum_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    curriculum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.id);
                    table.ForeignKey(
                        name: "FK_Links_curriculum_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professional_experiences",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    actual_job = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    curriculum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional_experiences", x => x.id);
                    table.ForeignKey(
                        name: "FK_professional_experiences_curriculum_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    link = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    curriculum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_curriculum_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tools",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tool_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    curriculum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tools", x => x.id);
                    table.ForeignKey(
                        name: "FK_tools_curriculum_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project_tool",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_tool", x => new { x.ProjectId, x.ToolId });
                    table.ForeignKey(
                        name: "FK_project_tool_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_project_tool_tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "tools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_curriculum_id",
                table: "address",
                column: "curriculum_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_courses_curriculum_id",
                table: "courses",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_formations_curriculum_id",
                table: "formations",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_languages_curriculum_id",
                table: "languages",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_Links_curriculum_id",
                table: "Links",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_professional_experiences_curriculum_id",
                table: "professional_experiences",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_tool_ToolId",
                table: "project_tool",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_curriculum_id",
                table: "projects",
                column: "curriculum_id");

            migrationBuilder.CreateIndex(
                name: "IX_tools_curriculum_id",
                table: "tools",
                column: "curriculum_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "formations");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "professional_experiences");

            migrationBuilder.DropTable(
                name: "project_tool");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "tools");

            migrationBuilder.DropTable(
                name: "curriculum");
        }
    }
}
