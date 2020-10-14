using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LOGO.Migrations
{
    public partial class DateResponsesPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

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

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ResponsesPatient",
                keyColumns: new[] { "PatientID", "ResponseID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ResponsesPatient",
                keyColumns: new[] { "PatientID", "ResponseID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ResponsesPatient",
                keyColumns: new[] { "PatientID", "ResponseID" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ResponsesPatient",
                keyColumns: new[] { "PatientID", "ResponseID" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ResponsesPatient",
                keyColumns: new[] { "PatientID", "ResponseID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ResponsesPatient",
                keyColumns: new[] { "PatientID", "ResponseID" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ResponsesPatient",
                keyColumns: new[] { "PatientID", "ResponseID" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ResponsesPatient",
                keyColumns: new[] { "PatientID", "ResponseID" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SpeechTherapists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SpeechTherapists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stimulis",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stimulis",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stimulis",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stimulis",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ResponsesPatient",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ResponsesPatient");

            migrationBuilder.InsertData(
                table: "SpeechTherapists",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "Password" },
                values: new object[,]
                {
                    { 1, "matilde", "Matilde", "Gravano", "matilde" },
                    { 2, "pelagie", "Pélagie", "Campos", "pelagie" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tâche 1: appariement de lettres" },
                    { 2, "Tâche 2 : Lecture de mots" },
                    { 3, "Tâche 3: Dénomination des objets" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Diagnostique", "Fullname", "LastTaskDoneID", "SpeechTherapistID" },
                values: new object[,]
                {
                    { 2, "dyslexique", "Maido kapo", 2, 1 },
                    { 3, "aphasique", "Jojo tousk", 2, 1 },
                    { 4, "dyslexique", "Charline Dupont", 1, 1 },
                    { 7, "dyslexique", "Elodie Filou", 2, 1 },
                    { 1, "dyslexique", "Pablo cousu", 1, 2 },
                    { 5, "dyslexique", "Benoit Blanc", 3, 2 },
                    { 6, "dyslexique", "Maxime Gros", 1, 2 },
                    { 8, "dyslexique", "Julie Desprez", 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Stimulis",
                columns: new[] { "Id", "Name", "TaskID" },
                values: new object[,]
                {
                    { 1, "A", 1 },
                    { 2, "B", 1 },
                    { 3, "C", 1 },
                    { 4, "D", 1 }
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "Id", "Choice", "StimuliID", "Type", "isGoodAnswer" },
                values: new object[,]
                {
                    { 1, "a", 1, 1, true },
                    { 2, "h", 1, 1, false },
                    { 3, "d", 2, 1, false },
                    { 4, "b", 2, 1, true },
                    { 5, "o", 3, 1, false },
                    { 6, "c", 3, 1, true },
                    { 7, "n", 4, 1, false },
                    { 8, "d", 4, 1, true }
                });

            migrationBuilder.InsertData(
                table: "ResponsesPatient",
                columns: new[] { "PatientID", "ResponseID" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 2, 5 },
                    { 3, 5 },
                    { 2, 7 },
                    { 3, 8 }
                });
        }
    }
}
