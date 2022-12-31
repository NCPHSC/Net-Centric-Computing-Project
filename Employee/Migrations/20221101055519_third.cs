using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notice",
                table: "Notice");

            migrationBuilder.DropColumn(
                name: "Publish",
                table: "Notice");

            migrationBuilder.RenameTable(
                name: "Notice",
                newName: "Notices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notices",
                table: "Notices",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notices",
                table: "Notices");

            migrationBuilder.RenameTable(
                name: "Notices",
                newName: "Notice");

            migrationBuilder.AddColumn<bool>(
                name: "Publish",
                table: "Notice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notice",
                table: "Notice",
                column: "Id");
        }
    }
}
