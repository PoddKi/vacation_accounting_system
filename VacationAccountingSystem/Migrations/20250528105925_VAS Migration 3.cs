using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationAccountingSystem.Migrations
{
    /// <inheritdoc />
    public partial class VASMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "function",
                table: "user",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "user",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "function",
                table: "user");

            migrationBuilder.DropColumn(
                name: "role",
                table: "user");
        }
    }
}
