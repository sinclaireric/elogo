using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LOGO.Migrations
{
    public partial class Email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "SpeechTherapists");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SpeechTherapists",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SpeechTherapists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "matilde");

            migrationBuilder.UpdateData(
                table: "SpeechTherapists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "pelagie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "SpeechTherapists");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "SpeechTherapists",
                type: "varchar(10) CHARACTER SET utf8mb4",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SpeechTherapists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "matilde");

            migrationBuilder.UpdateData(
                table: "SpeechTherapists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Username",
                value: "pelagie");
        }
    }
}
