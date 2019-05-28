using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SomeUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 24, 19, 19, 33, 770, DateTimeKind.Local).AddTicks(1140),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 24, 19, 11, 26, 106, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.AddColumn<Guid>(
                name: "LicenseId",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2019, 5, 24, 19, 11, 26, 106, DateTimeKind.Local).AddTicks(7435),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 5, 24, 19, 19, 33, 770, DateTimeKind.Local).AddTicks(1140));
        }
    }
}
