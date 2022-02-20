using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace if3250_2022_19_filantropi_backend.Migrations
{
    public partial class UserRemoveTestEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tes",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tes",
                table: "users",
                type: "text",
                nullable: true);
        }
    }
}
