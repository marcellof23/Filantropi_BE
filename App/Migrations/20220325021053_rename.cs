using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace if3250_2022_19_filantropi_backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "donasi",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "galangDanaId",
                table: "donasi",
                newName: "galangdana_id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "doa",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "galangDanaId",
                table: "doa",
                newName: "galangdana_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "donasi",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "galangdana_id",
                table: "donasi",
                newName: "galangDanaId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "doa",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "galangdana_id",
                table: "doa",
                newName: "galangDanaId");
        }
    }
}
