using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health.OS.APi.Migrations
{
    /// <inheritdoc />
    public partial class configuredcrudoperations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Patient",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Patient",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Patient",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OtherName",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "OtherName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Patient",
                newName: "Name");
        }
    }
}
