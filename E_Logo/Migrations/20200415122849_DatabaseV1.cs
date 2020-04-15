using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Logo.Migrations
{
    public partial class DatabaseV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpeechTherapists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(maxLength: 10, nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeechTherapists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SpeechTherapists",
                columns: new[] { "Id", "Firstname", "Lastname", "Password", "Username" },
                values: new object[] { 1, "Matilde", "Gravano", "matilde", "matilde" });

            migrationBuilder.InsertData(
                table: "SpeechTherapists",
                columns: new[] { "Id", "Firstname", "Lastname", "Password", "Username" },
                values: new object[] { 2, "Pélagie", "Lacroix", "pelagie", "pelagie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpeechTherapists");
        }
    }
}
