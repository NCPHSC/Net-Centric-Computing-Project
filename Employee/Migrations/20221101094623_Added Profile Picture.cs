using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Migrations
{
    public partial class AddedProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Staffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
