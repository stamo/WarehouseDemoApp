using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Infrastructure.Data.Migrations
{
    public partial class CategoriesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateFrom", "DateTo", "Description", "Label" },
                values: new object[,]
                {
                    { new Guid("0f1fa492-6a74-4b89-bde7-0f8d73d66277"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Computers" },
                    { new Guid("14153ce2-3e50-48a1-8c95-fd6910843ab0"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sunglasses" },
                    { new Guid("270ac1e4-1071-4538-9385-1f5ba82909cd"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Bikes" },
                    { new Guid("2ef69c5c-bf63-4641-aba4-06bc8d89f1dd"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Mobile phones" },
                    { new Guid("37222c64-dd03-4660-a9c7-7e16da8c7dfe"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Toys" },
                    { new Guid("647b7946-2555-450d-876d-872aa2aadfe2"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Monitors" },
                    { new Guid("77963acf-7b33-435f-9bed-5f926ece5bc3"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Food" },
                    { new Guid("a91908ba-0fd7-4426-ba29-96d07aafc329"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sporting clothes" },
                    { new Guid("afdca761-93c6-4472-b970-840bfdeb52e5"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Books" },
                    { new Guid("cf1c9eb4-5d97-45ef-9c35-570ffc6eca61"), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tablets" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0f1fa492-6a74-4b89-bde7-0f8d73d66277"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("14153ce2-3e50-48a1-8c95-fd6910843ab0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("270ac1e4-1071-4538-9385-1f5ba82909cd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2ef69c5c-bf63-4641-aba4-06bc8d89f1dd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("37222c64-dd03-4660-a9c7-7e16da8c7dfe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("647b7946-2555-450d-876d-872aa2aadfe2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("77963acf-7b33-435f-9bed-5f926ece5bc3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a91908ba-0fd7-4426-ba29-96d07aafc329"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("afdca761-93c6-4472-b970-840bfdeb52e5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cf1c9eb4-5d97-45ef-9c35-570ffc6eca61"));
        }
    }
}
