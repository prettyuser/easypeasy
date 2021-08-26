using Microsoft.EntityFrameworkCore.Migrations;

namespace Followers.Model.Migrations
{
    public partial class Migration03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Id",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Id",
                schema: "dbo",
                table: "Clients",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Id",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Id",
                schema: "dbo",
                table: "Clients",
                column: "Id");
        }
    }
}
