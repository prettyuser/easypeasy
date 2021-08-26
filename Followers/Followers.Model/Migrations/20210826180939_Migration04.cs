using Microsoft.EntityFrameworkCore.Migrations;

namespace Followers.Model.Migrations
{
    public partial class Migration04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Followers",
                schema: "dbo",
                newName: "Followers");

            migrationBuilder.RenameTable(
                name: "Clients",
                schema: "dbo",
                newName: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Followers",
                newName: "Followers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Clients",
                newSchema: "dbo");
        }
    }
}
