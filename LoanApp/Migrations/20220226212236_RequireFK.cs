using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAppMVC.Migrations
{
    public partial class RequireFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Demographics_OwnerId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApps_Businesses_BusinessId",
                table: "LoanApps");

            migrationBuilder.DropIndex(
                name: "IX_Demographics_Name_PhoneNo",
                table: "Demographics");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessId",
                table: "LoanApps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Demographics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Businesses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_Name_PhoneNo_Email",
                table: "Demographics",
                columns: new[] { "Name", "PhoneNo", "Email" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Demographics_OwnerId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApps_Businesses_BusinessId",
                table: "LoanApps");

            migrationBuilder.DropIndex(
                name: "IX_Demographics_Name_PhoneNo_Email",
                table: "Demographics");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessId",
                table: "LoanApps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Demographics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Businesses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_Name_PhoneNo",
                table: "Demographics",
                columns: new[] { "Name", "PhoneNo" });

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
    }
}
