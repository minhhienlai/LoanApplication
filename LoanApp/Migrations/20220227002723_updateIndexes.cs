using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAppMVC.Migrations
{
    public partial class updateIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoanApps_Amount_CreditScore_RiskRate",
                table: "LoanApps");

            migrationBuilder.DropIndex(
                name: "IX_Demographics_Name_PhoneNo_Email",
                table: "Demographics");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Demographics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Demographics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApps_Amount_CreditScore",
                table: "LoanApps",
                columns: new[] { "Amount", "CreditScore" });

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_Name",
                table: "Demographics",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoanApps_Amount_CreditScore",
                table: "LoanApps");

            migrationBuilder.DropIndex(
                name: "IX_Demographics_Name",
                table: "Demographics");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Demographics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Demographics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApps_Amount_CreditScore_RiskRate",
                table: "LoanApps",
                columns: new[] { "Amount", "CreditScore", "RiskRate" });

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_Name_PhoneNo_Email",
                table: "Demographics",
                columns: new[] { "Name", "PhoneNo", "Email" });
        }
    }
}
