using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedAddressList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Добавляем новые FK столбцы
            migrationBuilder.AddColumn<Guid>(
                name: "DefaultAddressId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            // 2. Создаём таблицу Addresses
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    BuildingNumber = table.Column<string>(type: "text", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "text", nullable: false),
                    Entrance = table.Column<string>(type: "text", nullable: true),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Entities_Id",
                        column: x => x.Id,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Id",
                table: "Addresses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            // 3. Переносим данные из Users.Profile_Address_* в Addresses
            migrationBuilder.Sql(
            @"
            DO $$
            DECLARE 
                uid uuid;
                rec record;
            BEGIN
                FOR rec IN
                    SELECT ""Id"", ""Profile_Address_City"", ""Profile_Address_Street"", ""Profile_Address_BuildingNumber"",
                           ""Profile_Address_ApartmentNumber"", ""Profile_Address_Entrance"", ""Profile_Address_Floor""
                    FROM ""Users""
                    WHERE ""Profile_Address_City"" IS NOT NULL
                LOOP
                    uid := gen_random_uuid();
                    INSERT INTO ""Entities"" (""Id"", ""Timestamps_CreatedAt"", ""Timestamps_UpdatedAt"")
                    VALUES (uid, now(), now());
                    INSERT INTO ""Addresses"" (
                        ""Id"", ""City"", ""Street"", ""BuildingNumber"", ""ApartmentNumber"", ""Entrance"", ""Floor"", ""UserId"")
                    VALUES (
                        uid,
                        rec.""Profile_Address_City"",
                        rec.""Profile_Address_Street"",
                        rec.""Profile_Address_BuildingNumber"",
                        rec.""Profile_Address_ApartmentNumber"",
                        rec.""Profile_Address_Entrance"",
                        COALESCE(rec.""Profile_Address_Floor"", 0),
                        rec.""Id"");
                    UPDATE ""Users"" SET ""DefaultAddressId"" = uid WHERE ""Id"" = rec.""Id"";
                END LOOP;
            END $$;
            ");

            // 4. Переносим данные из Orders.Address_* в Addresses
            migrationBuilder.Sql(
            @"
            DO $$
            DECLARE 
                oid uuid;
                rec record;
            BEGIN
                FOR rec IN
                    SELECT ""Id"", ""UserId"", ""Address_City"", ""Address_Street"", ""Address_BuildingNumber"",
                           ""Address_ApartmentNumber"", ""Address_Entrance"", ""Address_Floor""
                    FROM ""Orders""
                    WHERE ""Address_City"" IS NOT NULL
                LOOP
                    oid := gen_random_uuid();
                    INSERT INTO ""Entities"" (""Id"", ""Timestamps_CreatedAt"", ""Timestamps_UpdatedAt"")
                    VALUES (oid, now(), now());
                    INSERT INTO ""Addresses"" (
                        ""Id"", ""City"", ""Street"", ""BuildingNumber"", ""ApartmentNumber"", ""Entrance"", ""Floor"", ""UserId"")
                    VALUES (
                        oid,
                        rec.""Address_City"",
                        rec.""Address_Street"",
                        rec.""Address_BuildingNumber"",
                        rec.""Address_ApartmentNumber"",
                        rec.""Address_Entrance"",
                        COALESCE(rec.""Address_Floor"", 0),
                        rec.""UserId"");
                    UPDATE ""Orders"" SET ""AddressId"" = oid WHERE ""Id"" = rec.""Id"";
                END LOOP;
            END $$;
            ");

            // 5. Удаляем старые колонки
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

            migrationBuilder.DropColumn(
                name: "Address_ApartmentNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address_BuildingNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address_Entrance",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address_Floor",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DefaultAddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Orders");

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

            migrationBuilder.AddColumn<string>(
                name: "Address_ApartmentNumber",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_BuildingNumber",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Entrance",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_Floor",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Orders",
                type: "text",
                nullable: true);
        }
    }
}
