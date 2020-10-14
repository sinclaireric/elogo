using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LOGO.Migrations
{
    public partial class ResponsesPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Patients_PatientId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_PatientId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "LastTaskDone",
                table: "Patients");

            migrationBuilder.AddColumn<bool>(
                name: "isGoodAnswer",
                table: "Responses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LastTaskDoneID",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResponsesPatient",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false),
                    ResponseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsesPatient", x => new { x.PatientID, x.ResponseID });
                    table.ForeignKey(
                        name: "FK_ResponsesPatient_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsesPatient_Responses_ResponseID",
                        column: x => x.ResponseID,
                        principalTable: "Responses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastTaskDoneID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastTaskDoneID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastTaskDoneID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastTaskDoneID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastTaskDoneID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastTaskDoneID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastTaskDoneID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastTaskDoneID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 1,
                column: "isGoodAnswer",
                value: true);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 4,
                column: "isGoodAnswer",
                value: true);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 6,
                column: "isGoodAnswer",
                value: true);

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 8,
                column: "isGoodAnswer",
                value: true);

            migrationBuilder.InsertData(
                table: "ResponsesPatient",
                columns: new[] { "PatientID", "ResponseID" },
                values: new object[,]
                {
                    { 3, 5 },
                    { 3, 4 },
                    { 3, 2 },
                    { 2, 7 },
                    { 2, 5 },
                    { 2, 3 },
                    { 3, 8 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsesPatient_ResponseID",
                table: "ResponsesPatient",
                column: "ResponseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsesPatient");

            migrationBuilder.DropColumn(
                name: "isGoodAnswer",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "LastTaskDoneID",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Responses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastTaskDone",
                table: "Patients",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastTaskDone",
                value: "no one");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastTaskDone",
                value: "5B");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastTaskDone",
                value: "17A");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastTaskDone",
                value: "5B");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastTaskDone",
                value: "5B");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastTaskDone",
                value: "5B");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastTaskDone",
                value: "5B");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastTaskDone",
                value: "5B");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_PatientId",
                table: "Responses",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Patients_PatientId",
                table: "Responses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
