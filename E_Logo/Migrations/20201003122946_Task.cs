using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LOGO.Migrations
{
    public partial class Task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Results",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stimuli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TaskID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stimuli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stimuli_Task_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    StimuliID = table.Column<int>(nullable: false),
                    Choice = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Response_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_Stimuli_StimuliID",
                        column: x => x.StimuliID,
                        principalTable: "Stimuli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Diagnostique", "Fullname", "LastTaskDone", "SpeechTherapistID" },
                values: new object[,]
                {
                    { 4, "dyslexique", "Charline Dupont", "5B", 1 },
                    { 5, "dyslexique", "Benoit Blanc", "5B", 2 },
                    { 6, "dyslexique", "Maxime Gros", "5B", 2 },
                    { 7, "dyslexique", "Elodie Filou", "5B", 1 },
                    { 8, "dyslexique", "Julie Desprez", "5B", 2 }
                });

            migrationBuilder.UpdateData(
                table: "SpeechTherapists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Lastname",
                value: "Campos");

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tâche 1: appariement de lettres" },
                    { 2, "Tâche 2 : Lecture de mots" },
                    { 3, "Tâche 3: Dénomination des objets" }
                });

            migrationBuilder.InsertData(
                table: "Stimuli",
                columns: new[] { "Id", "Name", "TaskID" },
                values: new object[,]
                {
                    { 1, "A", 1 },
                    { 2, "B", 1 },
                    { 3, "C", 1 },
                    { 4, "D", 1 }
                });

            migrationBuilder.InsertData(
                table: "Response",
                columns: new[] { "Id", "Choice", "PatientId", "StimuliID", "Type" },
                values: new object[,]
                {
                    { 1, "a", null, 1, 1 },
                    { 2, "h", null, 1, 1 },
                    { 3, "d", null, 2, 1 },
                    { 4, "b", null, 2, 1 },
                    { 5, "o", null, 3, 1 },
                    { 6, "c", null, 3, 1 },
                    { 7, "n", null, 4, 1 },
                    { 8, "d", null, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Fullname",
                table: "Patients",
                column: "Fullname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Response_PatientId",
                table: "Response",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_StimuliID",
                table: "Response",
                column: "StimuliID");

            migrationBuilder.CreateIndex(
                name: "IX_Stimuli_Name",
                table: "Stimuli",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stimuli_TaskID",
                table: "Stimuli",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Name",
                table: "Task",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "Stimuli");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Fullname",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Patients",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Results",
                table: "Patients",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Results",
                value: "not defined");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Results",
                value: "not defined");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Results",
                value: "0/20");

            migrationBuilder.UpdateData(
                table: "SpeechTherapists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Lastname",
                value: "Lacroix");
        }
    }
}
