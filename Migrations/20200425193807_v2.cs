using Microsoft.EntityFrameworkCore.Migrations;

namespace IST440Team3.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OutputLanguage",
                table: "Transformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutputLanguage",
                table: "Transformation");
        }
    }
}
