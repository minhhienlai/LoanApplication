using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAppMVC.Migrations
{
    public partial class UpdateOptionalFK_Temp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Demographics_OwnerId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApps_Businesses_BusinessId",
                table: "LoanApps");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessId",
                table: "LoanApps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Businesses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Demographics_OwnerId",
                table: "Businesses",
                column: "OwnerId",
                principalTable: "Demographics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApps_Businesses_BusinessId",
                table: "LoanApps",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Demographics_OwnerId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApps_Businesses_BusinessId",
                table: "LoanApps");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessId",
                table: "LoanApps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Businesses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Demographics_OwnerId",
                table: "Businesses",
                column: "OwnerId",
                principalTable: "Demographics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApps_Businesses_BusinessId",
                table: "LoanApps",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
