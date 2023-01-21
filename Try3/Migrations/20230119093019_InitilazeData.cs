using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Try3.Migrations
{
    public partial class InitilazeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) //Create, isert, updates 
        {
            migrationBuilder.EnsureSchema(
                name: "College");

            migrationBuilder.EnsureSchema(
                name: "College");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "College",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.departmentId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "College",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentName = table.Column<string>(type: "varchar(200)", nullable: false),
                    majorName = table.Column<string>(type: "varchar(200)", nullable: true),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_Student_Department_departmentId",
                        column: x => x.departmentId,
                        principalSchema: "College",
                        principalTable: "Department",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_departmentId",
                schema: "College",
                table: "Student",
                column: "departmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder) //Free resourses and drop tables
        {
            migrationBuilder.DropTable(
                name: "Student",
                schema: "College");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "College");
        }
    }
}
