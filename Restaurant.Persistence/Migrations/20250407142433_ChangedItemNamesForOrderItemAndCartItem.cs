using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedItemNamesForOrderItemAndCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "CartDishItems"
            );
            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderDishItems"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "CartDishItems",
                newName: "CartItem"
            );
            migrationBuilder.RenameTable(
                name: "OrderDishItems",
                newName: "OrderItem"
            );
        }
    }
}
