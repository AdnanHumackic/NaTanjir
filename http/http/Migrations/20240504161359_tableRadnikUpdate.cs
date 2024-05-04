using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace http.Migrations
{
    /// <inheritdoc />
    public partial class tableRadnikUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestoranID",
                table: "Radnik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Radnik_RestoranID",
                table: "Radnik",
                column: "RestoranID");

            migrationBuilder.AddForeignKey(
                name: "FK_Radnik_Restoran_RestoranID",
                table: "Radnik",
                column: "RestoranID",
                principalTable: "Restoran",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Radnik_Restoran_RestoranID",
                table: "Radnik");

            migrationBuilder.DropIndex(
                name: "IX_Radnik_RestoranID",
                table: "Radnik");

            migrationBuilder.DropColumn(
                name: "RestoranID",
                table: "Radnik");
        }
    }
}
