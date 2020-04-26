using Microsoft.EntityFrameworkCore.Migrations;

namespace IST440Team3.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EvidenceNumber",
                table: "Transformation",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvidenceNumber",
                table: "Transformation");
        }
    }
}
