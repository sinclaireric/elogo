using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LOGO.Migrations
{
    public partial class Patients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fullname = table.Column<string>(nullable: false),
                    Results = table.Column<string>(nullable: true),
                    Diagnostique = table.Column<string>(nullable: true),
                    LastTaskDone = table.Column<string>(nullable: true),
                    SpeechTherapistID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_SpeechTherapists_SpeechTherapistID",
                        column: x => x.SpeechTherapistID,
                        principalTable: "SpeechTherapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Diagnostique", "Fullname", "LastTaskDone", "Results", "SpeechTherapistID" },
                values: new object[] { 1, "dyslexique", "Pablo cousu", "no one", "not defined", 2 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Diagnostique", "Fullname", "LastTaskDone", "Results", "SpeechTherapistID" },
                values: new object[] { 2, "dyslexique", "Maido kapo", "5B", "not defined", 1 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Diagnostique", "Fullname", "LastTaskDone", "Results", "SpeechTherapistID" },
                values: new object[] { 3, "aphasique", "Jojo tousk", "17A", "0/20", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SpeechTherapists_Email",
                table: "SpeechTherapists",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SpeechTherapistID",
                table: "Patients",
                column: "SpeechTherapistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_SpeechTherapists_Email",
                table: "SpeechTherapists");
        }
    }
}
