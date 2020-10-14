using Microsoft.EntityFrameworkCore.Migrations;

namespace E_LOGO.Migrations
{
    public partial class TasksResponsesStimulis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_Patients_PatientId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Stimuli_StimuliID",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Stimuli_Task_TaskID",
                table: "Stimuli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stimuli",
                table: "Stimuli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Response",
                table: "Response");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "Stimuli",
                newName: "Stimulis");

            migrationBuilder.RenameTable(
                name: "Response",
                newName: "Responses");

            migrationBuilder.RenameIndex(
                name: "IX_Task_Name",
                table: "Tasks",
                newName: "IX_Tasks_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Stimuli_TaskID",
                table: "Stimulis",
                newName: "IX_Stimulis_TaskID");

            migrationBuilder.RenameIndex(
                name: "IX_Stimuli_Name",
                table: "Stimulis",
                newName: "IX_Stimulis_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Response_StimuliID",
                table: "Responses",
                newName: "IX_Responses_StimuliID");

            migrationBuilder.RenameIndex(
                name: "IX_Response_PatientId",
                table: "Responses",
                newName: "IX_Responses_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stimulis",
                table: "Stimulis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Patients_PatientId",
                table: "Responses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Stimulis_StimuliID",
                table: "Responses",
                column: "StimuliID",
                principalTable: "Stimulis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stimulis_Tasks_TaskID",
                table: "Stimulis",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Patients_PatientId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Stimulis_StimuliID",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Stimulis_Tasks_TaskID",
                table: "Stimulis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stimulis",
                table: "Stimulis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "Stimulis",
                newName: "Stimuli");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "Response");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_Name",
                table: "Task",
                newName: "IX_Task_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Stimulis_TaskID",
                table: "Stimuli",
                newName: "IX_Stimuli_TaskID");

            migrationBuilder.RenameIndex(
                name: "IX_Stimulis_Name",
                table: "Stimuli",
                newName: "IX_Stimuli_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_StimuliID",
                table: "Response",
                newName: "IX_Response_StimuliID");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_PatientId",
                table: "Response",
                newName: "IX_Response_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stimuli",
                table: "Stimuli",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Response",
                table: "Response",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Patients_PatientId",
                table: "Response",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Stimuli_StimuliID",
                table: "Response",
                column: "StimuliID",
                principalTable: "Stimuli",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stimuli_Task_TaskID",
                table: "Stimuli",
                column: "TaskID",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
