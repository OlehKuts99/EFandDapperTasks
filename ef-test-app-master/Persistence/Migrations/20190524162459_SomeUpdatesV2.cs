using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SomeUpdatesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Customers_CustomerId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_CustomerId",
                table: "Licenses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 24, 19, 24, 59, 177, DateTimeKind.Local).AddTicks(9035),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 24, 19, 19, 33, 770, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Licenses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_CustomerId",
                table: "Licenses",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Customers_CustomerId",
                table: "Licenses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Customers_CustomerId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_CustomerId",
                table: "Licenses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 24, 19, 19, 33, 770, DateTimeKind.Local).AddTicks(1140),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 24, 19, 24, 59, 177, DateTimeKind.Local).AddTicks(9035));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Licenses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_CustomerId",
                table: "Licenses",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Customers_CustomerId",
                table: "Licenses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
