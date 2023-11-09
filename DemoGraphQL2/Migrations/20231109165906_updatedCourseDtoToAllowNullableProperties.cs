using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoGraphQL2.Migrations
{
    public partial class updatedCourseDtoToAllowNullableProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDtos_InstructorDtos_InstructorId",
                table: "CourseDtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "CourseDtos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDtos_InstructorDtos_InstructorId",
                table: "CourseDtos",
                column: "InstructorId",
                principalTable: "InstructorDtos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDtos_InstructorDtos_InstructorId",
                table: "CourseDtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "CourseDtos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDtos_InstructorDtos_InstructorId",
                table: "CourseDtos",
                column: "InstructorId",
                principalTable: "InstructorDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
