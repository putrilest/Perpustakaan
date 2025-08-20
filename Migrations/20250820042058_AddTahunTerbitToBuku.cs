using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerpustakaanMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddTahunTerbitToBuku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JumlahHalaman",
                table: "Buku",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TahunTerbit",
                table: "Buku",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JumlahHalaman",
                table: "Buku");

            migrationBuilder.DropColumn(
                name: "TahunTerbit",
                table: "Buku");
        }
    }
}
