using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "orderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Name", "RefreshToken", "RefreshTokenTime", "Role", "password" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "123 Main St", "Alice", null, null, "Customer", "password" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "Bob", null, null, "Admin", "adminpass" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Created_at", "UserId" },
                values: new object[] { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "PlacedAt", "ShippingAddress", "Status", "TotalAmount", "UserId" },
                values: new object[] { 1, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "123 Main St", "Pending", 1200.00m, new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategotyId", "Desciption", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Gaming Laptop", "Laptop" },
                    { 2, 2, "Learn C#", "C# Programming" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "orderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[] { 1, 1, 1, 1, 1200.00m });
        }
    }
}
