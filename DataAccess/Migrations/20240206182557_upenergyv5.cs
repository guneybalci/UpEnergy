using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class upenergyv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "FuelOils",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FuelOils_CarId",
                table: "FuelOils",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_FuelOils_Cars_CarId",
                table: "FuelOils",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuelOils_Cars_CarId",
                table: "FuelOils");

            migrationBuilder.DropIndex(
                name: "IX_FuelOils_CarId",
                table: "FuelOils");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "FuelOils");
        }
    }
}
