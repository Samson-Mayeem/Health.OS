using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health.OS.APi.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnCalls_AspNetUsers_NurseId",
                table: "OnCalls");

            migrationBuilder.RenameColumn(
                name: "INo",
                table: "Patient",
                newName: "IsuranceNo");

            migrationBuilder.RenameColumn(
                name: "ICompany",
                table: "Patient",
                newName: "IsuranceCompany");

            migrationBuilder.RenameColumn(
                name: "NurseId",
                table: "OnCalls",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OnCalls_NurseId",
                table: "OnCalls",
                newName: "IX_OnCalls_UserId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_OnCalls_AspNetUsers_UserId",
                table: "OnCalls",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnCalls_AspNetUsers_UserId",
                table: "OnCalls");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsuranceNo",
                table: "Patient",
                newName: "INo");

            migrationBuilder.RenameColumn(
                name: "IsuranceCompany",
                table: "Patient",
                newName: "ICompany");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OnCalls",
                newName: "NurseId");

            migrationBuilder.RenameIndex(
                name: "IX_OnCalls_UserId",
                table: "OnCalls",
                newName: "IX_OnCalls_NurseId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_OnCalls_AspNetUsers_NurseId",
                table: "OnCalls",
                column: "NurseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
