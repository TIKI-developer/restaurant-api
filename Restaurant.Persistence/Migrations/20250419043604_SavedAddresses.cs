using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SavedAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefaultAddressId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Promotions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdvanced",
                table: "Promotions",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Promotions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "SavedAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    Address_BuildingNumber = table.Column<string>(type: "text", nullable: false),
                    Address_ApartmentNumber = table.Column<string>(type: "text", nullable: false),
                    Address_Entrance = table.Column<string>(type: "text", nullable: true),
                    Address_Floor = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedAddresses_Entities_Id",
                        column: x => x.Id,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedAddresses_Id",
                table: "SavedAddresses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedAddresses_UserId",
                table: "SavedAddresses",
                column: "UserId");

            migrationBuilder.Sql(@"
                WITH generated AS (
                    SELECT 
                        gen_random_uuid() AS id,
                        now() AS created_at,
                        now() AS updated_at,
                        u.""Id"" AS user_id,
                        u.""Profile_Address_City"",
                        u.""Profile_Address_Street"",
                        u.""Profile_Address_BuildingNumber"",
                        u.""Profile_Address_ApartmentNumber"",
                        u.""Profile_Address_Entrance"",
                        u.""Profile_Address_Floor""
                    FROM ""Users"" u
                    WHERE 
                        u.""Profile_Address_City"" IS NOT NULL AND
                        u.""Profile_Address_Street"" IS NOT NULL AND
                        u.""Profile_Address_BuildingNumber"" IS NOT NULL AND
                        u.""Profile_Address_ApartmentNumber"" IS NOT NULL AND
                        u.""Profile_Address_Floor"" IS NOT NULL
                ),
                insert_entities AS (
                    INSERT INTO ""Entities"" (""Id"", ""Timestamps_CreatedAt"", ""Timestamps_UpdatedAt"")
                    SELECT id, created_at, updated_at
                    FROM generated
                    RETURNING ""Id""
                )
                INSERT INTO ""SavedAddresses"" (
                    ""Id"",
                    ""Name"",
                    ""Address_City"",
                    ""Address_Street"",
                    ""Address_BuildingNumber"",
                    ""Address_ApartmentNumber"",
                    ""Address_Entrance"",
                    ""Address_Floor"",
                    ""UserId""
                )
                SELECT 
                    g.id,
                    'Дом',
                    g.""Profile_Address_City"",
                    g.""Profile_Address_Street"",
                    g.""Profile_Address_BuildingNumber"",
                    g.""Profile_Address_ApartmentNumber"",
                    g.""Profile_Address_Entrance"",
                    g.""Profile_Address_Floor"",
                    g.user_id
                FROM generated g;
            ");

            migrationBuilder.DropColumn(
                name: "Profile_Address_ApartmentNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Profile_Address_BuildingNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Profile_Address_City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Profile_Address_Entrance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Profile_Address_Floor",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Profile_Address_Street",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profile_Address_ApartmentNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Address_BuildingNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Address_City",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Address_Entrance",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Profile_Address_Floor",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Address_Street",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.Sql(@"
                UPDATE ""Users"" u
                SET 
                    ""Profile_Address_City"" = sa.""Address_City"",
                    ""Profile_Address_Street"" = sa.""Address_Street"",
                    ""Profile_Address_BuildingNumber"" = sa.""Address_BuildingNumber"",
                    ""Profile_Address_ApartmentNumber"" = sa.""Address_ApartmentNumber"",
                    ""Profile_Address_Entrance"" = sa.""Address_Entrance"",
                    ""Profile_Address_Floor"" = sa.""Address_Floor""
                FROM (
                    SELECT DISTINCT ON (""UserId"") *
                    FROM ""SavedAddresses"" 
                    ORDER BY ""UserId"", ""Name""
                ) sa
                WHERE sa.""UserId"" = u.""Id"";

                DELETE FROM ""Entities"" 
                WHERE ""Id"" IN (
                    SELECT sa.""Id""
                    FROM ""SavedAddresses"" sa
                );
                DELETE FROM ""SavedAddresses"";
            ");

            migrationBuilder.DropTable(
                name: "SavedAddresses");

            migrationBuilder.DropColumn(
                name: "DefaultAddressId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Promotions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdvanced",
                table: "Promotions",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Promotions",
                type: "text", 
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
