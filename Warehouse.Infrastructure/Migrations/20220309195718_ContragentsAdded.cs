using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Infrastructure.Data.Migrations
{
    public partial class ContragentsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rack_Items_ItemId",
                table: "Rack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rack",
                table: "Rack");

            migrationBuilder.RenameTable(
                name: "Rack",
                newName: "Racks");

            migrationBuilder.RenameIndex(
                name: "IX_Rack_ItemId",
                table: "Racks",
                newName: "IX_Racks_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Racks",
                table: "Racks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Contragents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LoyaltyCard = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contragents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContragentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deals_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DealSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealSubjects_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealSubjects_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deals_ContragentId",
                table: "Deals",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_DealSubjects_DealId",
                table: "DealSubjects",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_DealSubjects_ItemId",
                table: "DealSubjects",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Racks_Items_ItemId",
                table: "Racks",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racks_Items_ItemId",
                table: "Racks");

            migrationBuilder.DropTable(
                name: "DealSubjects");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Contragents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Racks",
                table: "Racks");

            migrationBuilder.RenameTable(
                name: "Racks",
                newName: "Rack");

            migrationBuilder.RenameIndex(
                name: "IX_Racks_ItemId",
                table: "Rack",
                newName: "IX_Rack_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rack",
                table: "Rack",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rack_Items_ItemId",
                table: "Rack",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
