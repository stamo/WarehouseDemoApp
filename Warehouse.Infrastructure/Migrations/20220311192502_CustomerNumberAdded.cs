using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Infrastructure.Data.Migrations
{
    public partial class CustomerNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerNumber",
                table: "Contragents",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contragents_CustomerNumber",
                table: "Contragents",
                column: "CustomerNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contragents_CustomerNumber",
                table: "Contragents");

            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "Contragents");
        }
    }
}
