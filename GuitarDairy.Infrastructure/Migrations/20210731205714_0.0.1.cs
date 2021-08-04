using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarDairy.Infrastructure.EF.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Entries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
