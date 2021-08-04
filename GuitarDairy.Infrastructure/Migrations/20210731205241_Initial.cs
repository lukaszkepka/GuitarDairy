using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarDairy.Infrastructure.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ExerciseId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1L, "Warmup", null },
                    { 2L, "Rhythm", null },
                    { 3L, "Soloing", null },
                    { 4L, "Jazz", null },
                    { 5L, "Funk", null }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { 2L, 1L, "", "Eugene's trickbag" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { 3L, 3L, "", "Chromatics" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { 1L, 4L, "", "Altered Scale" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Date", "Duration", "ExerciseId", "Name", "UserId" },
                values: new object[] { 2L, new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 0, 30, 0, 0), 2L, null, 0L });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Date", "Duration", "ExerciseId", "Name", "UserId" },
                values: new object[] { 3L, new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 0, 30, 0, 0), 3L, null, 0L });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Date", "Duration", "ExerciseId", "Name", "UserId" },
                values: new object[] { 1L, new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 0, 30, 0, 0), 1L, null, 0L });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ExerciseId",
                table: "Entries",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoryId",
                table: "Exercises",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
