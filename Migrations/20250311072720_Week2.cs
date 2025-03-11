using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WApp.Migrations
{
    /// <inheritdoc />
    public partial class Week2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    StreamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.StreamId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StreamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "StreamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StreamId = table.Column<int>(type: "int", nullable: false),
                    SubName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => new { x.SubId, x.StreamId });
                    table.ForeignKey(
                        name: "FK_Subjects_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "StreamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TotalMarksObtained = table.Column<double>(type: "float", nullable: false),
                    PassFail = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => new { x.StudentId, x.Year });
                    table.ForeignKey(
                        name: "FK_Results_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearlyGpas",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    YGpa = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlyGpas", x => new { x.StudentId, x.Year });
                    table.ForeignKey(
                        name: "FK_YearlyGpas_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectResults",
                columns: table => new
                {
                    SubId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StreamId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarksObtained = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectResults", x => new { x.SubId, x.StreamId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_SubjectResults_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectResults_Subjects_SubId_StreamId",
                        columns: x => new { x.SubId, x.StreamId },
                        principalTable: "Subjects",
                        principalColumns: new[] { "SubId", "StreamId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Streams",
                columns: new[] { "StreamId", "Name" },
                values: new object[,]
                {
                    { 1, "Computer Engineering" },
                    { 2, "IT" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "StreamId", "SubId", "SubName", "Year" },
                values: new object[,]
                {
                    { 1, "AM", "Applied Maths", 1 },
                    { 2, "AM", "Applied Maths", 1 },
                    { 1, "C", "Logic Building with C", 1 },
                    { 2, "C", "Logic Building with C", 1 },
                    { 2, "CA", "Computer Architecture", 2 },
                    { 1, "CC", "Compiler Construction", 2 },
                    { 1, "CHEM", "Chemistry", 1 },
                    { 2, "CHEM", "Chemistry", 1 },
                    { 1, "COMM", "Communication", 1 },
                    { 2, "COMM", "Communication", 1 },
                    { 1, "DBMS", "Database Management System", 2 },
                    { 1, "DM", "Discrete Mathematics", 2 },
                    { 2, "DM", "Discrete Mathematics", 2 },
                    { 1, "DS", "Data Structures", 2 },
                    { 2, "OS", "Operating System", 2 },
                    { 1, "PHYS", "Physics", 1 },
                    { 2, "PHYS", "Physics", 1 },
                    { 1, "PY", "Python", 2 },
                    { 2, "PY", "Python", 2 },
                    { 2, "TOC", "Theory of Computation", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Streams_Name",
                table: "Streams",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StreamId",
                table: "Students",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectResults_StudentId",
                table: "SubjectResults",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Year_StreamId",
                table: "Subjects",
                columns: new[] { "Year", "StreamId" });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StreamId",
                table: "Subjects",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "SubjectResults");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "YearlyGpas");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Streams");
        }
    }
}
