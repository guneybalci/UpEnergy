using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class upenergyv6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Balances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_CustomerId",
                table: "Balances",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Customers_CustomerId",
                table: "Balances",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Customers_CustomerId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_CustomerId",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Balances");
        }
    }
}
