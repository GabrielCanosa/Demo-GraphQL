using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoGraphQL2.Migrations
{
    public partial class EntityFrameworkAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstructorDtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentDtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseDtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDtos_InstructorDtos_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "InstructorDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDtoStudentDto",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDtoStudentDto", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseDtoStudentDto_CourseDtos_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "CourseDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDtoStudentDto_StudentDtos_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "StudentDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDtos_InstructorId",
                table: "CourseDtos",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDtoStudentDto_StudentsId",
                table: "CourseDtoStudentDto",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDtoStudentDto");

            migrationBuilder.DropTable(
                name: "CourseDtos");

            migrationBuilder.DropTable(
                name: "StudentDtos");

            migrationBuilder.DropTable(
                name: "InstructorDtos");
        }
    }
}
