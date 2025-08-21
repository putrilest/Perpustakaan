using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerpustakaanMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddSampulToBuku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoSampul",
                table: "Buku",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoSampul",
                table: "Buku");
        }
    }
}
