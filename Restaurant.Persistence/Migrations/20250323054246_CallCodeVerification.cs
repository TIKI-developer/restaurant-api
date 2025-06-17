using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CallCodeVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallCode",
                table: "Verifications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CallId",
                table: "Verifications",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallCode",
                table: "Verifications");

            migrationBuilder.DropColumn(
                name: "CallId",
                table: "Verifications");
        }
    }
}
