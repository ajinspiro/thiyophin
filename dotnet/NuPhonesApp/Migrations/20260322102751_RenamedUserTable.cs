using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuPhonesApp.Migrations
{
    /// <inheritdoc />
    public partial class RenamedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users1",
                table: "Users1",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users1",
                table: "Users1");

            migrationBuilder.RenameTable(
                name: "Users1",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
