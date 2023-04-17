using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GripFoodEntities.Migrations
{
    public partial class GripFoodMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Name" },
                values: new object[] { "01GY6RZ9X65QR5WMKGXEBTV1C3", "Geprek Sambal Bakar" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Name" },
                values: new object[] { "01GY6RZ9X6DJ4Q712S7314DFG4", "Warung Pak Eko" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Name" },
                values: new object[] { "01GY6RZ9X6W38Z0B9NX9SPVT7R", "Kafe Hijau" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { "01GY6RZ9X63A2DX1DPGG9JZ9E0", "user01@gmail.com", "user01", "password123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { "01GY6RZ9X6F52CBC9NFD3YGG2H", "user03@gmail.com", "user03", "password312" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { "01GY6RZ9X6XE89K32EAVKASWXF", "user02@gmail.com", "user02", "password231" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Name", "Price", "RestaurantId" },
                values: new object[] { "01GY6RZ9X614BW04Y4W5PADAH7", "Geprek Ayam", 12000, "01GY6RZ9X65QR5WMKGXEBTV1C3" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Name", "Price", "RestaurantId" },
                values: new object[] { "01GY6RZ9X674AZTTNKGA8ZVBXJ", "Mie Geprek", 15000, "01GY6RZ9X65QR5WMKGXEBTV1C3" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Name", "Price", "RestaurantId" },
                values: new object[] { "01GY6RZ9X6EYBY2Z23QX7GXNVM", "Cappucino Cincau", 11000, "01GY6RZ9X6W38Z0B9NX9SPVT7R" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Name", "Price", "RestaurantId" },
                values: new object[] { "01GY6RZ9X6WXSEFS0WB170SHXG", "Mocha Latte", 21000, "01GY6RZ9X6W38Z0B9NX9SPVT7R" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Name", "Price", "RestaurantId" },
                values: new object[] { "01GY6RZ9X6XJJMAX76B9F2RKTQ", "Empal Goreng", 10000, "01GY6RZ9X6DJ4Q712S7314DFG4" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Name", "Price", "RestaurantId" },
                values: new object[] { "01GY6RZ9X6XTW8KHAEX7RSTHN0", "Telur Balado", 6000, "01GY6RZ9X6DJ4Q712S7314DFG4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X614BW04Y4W5PADAH7");

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X674AZTTNKGA8ZVBXJ");

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X6EYBY2Z23QX7GXNVM");

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X6WXSEFS0WB170SHXG");

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X6XJJMAX76B9F2RKTQ");

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X6XTW8KHAEX7RSTHN0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X63A2DX1DPGG9JZ9E0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X6F52CBC9NFD3YGG2H");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X6XE89K32EAVKASWXF");

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X65QR5WMKGXEBTV1C3");

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X6DJ4Q712S7314DFG4");

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: "01GY6RZ9X6W38Z0B9NX9SPVT7R");
        }
    }
}
