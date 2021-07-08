using Microsoft.EntityFrameworkCore.Migrations;

namespace BonillaApp.Migrations
{
    public partial class Device_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voltajes_Devices_DeviceId",
                table: "Voltajes");

            migrationBuilder.AlterColumn<float>(
                name: "Voltaje",
                table: "Voltajes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Voltajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Voltajes_Devices_DeviceId",
                table: "Voltajes",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voltajes_Devices_DeviceId",
                table: "Voltajes");

            migrationBuilder.AlterColumn<int>(
                name: "Voltaje",
                table: "Voltajes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Voltajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Voltajes_Devices_DeviceId",
                table: "Voltajes",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
