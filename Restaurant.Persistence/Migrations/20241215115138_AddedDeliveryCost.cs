using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeliveryCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DeliveryCost",
                table: "Orders",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryCost",
                table: "Orders");
        }
    }
}
