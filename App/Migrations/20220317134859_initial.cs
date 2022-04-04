using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace if3250_2022_19_filantropi_backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doa_donasi_donasi_id",
                table: "doa");

            migrationBuilder.RenameColumn(
                name: "donasiId",
                table: "doa",
                newName: "galangDanaId");

            migrationBuilder.RenameIndex(
                name: "ix_doa_donasi_id",
                table: "doa",
                newName: "ix_doa_galang_dana_id");

            migrationBuilder.AddForeignKey(
                name: "fk_doa_galangan_dana_galang_dana_id",
                table: "doa",
                column: "galangDanaId",
                principalTable: "galangan_dana",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doa_galangan_dana_galang_dana_id",
                table: "doa");

            migrationBuilder.RenameColumn(
                name: "galangDanaId",
                table: "doa",
                newName: "donasiId");

            migrationBuilder.RenameIndex(
                name: "ix_doa_galang_dana_id",
                table: "doa",
                newName: "ix_doa_donasi_id");

            migrationBuilder.AddForeignKey(
                name: "fk_doa_donasi_donasi_id",
                table: "doa",
                column: "donasiId",
                principalTable: "donasi",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
