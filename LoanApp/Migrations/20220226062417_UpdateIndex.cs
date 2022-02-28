using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAppMVC.Migrations
{
    public partial class UpdateIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Demographics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Demographics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Businesses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessCode",
                table: "Businesses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApps_Amount_CreditScore_RiskRate",
                table: "LoanApps",
                columns: new[] { "Amount", "CreditScore", "RiskRate" });

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_Name_PhoneNo",
                table: "Demographics",
                columns: new[] { "Name", "PhoneNo" });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_BusinessCode_Name",
                table: "Businesses",
                columns: new[] { "BusinessCode", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoanApps_Amount_CreditScore_RiskRate",
                table: "LoanApps");

            migrationBuilder.DropIndex(
                name: "IX_Demographics_Name_PhoneNo",
                table: "Demographics");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_BusinessCode_Name",
                table: "Businesses");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Demographics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Demographics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessCode",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
