using Microsoft.EntityFrameworkCore.Migrations;

namespace Followers.Model.Migrations
{
    public partial class Migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Followers_FollowerId",
                schema: "dbo",
                table: "Followers",
                sql: "[FollowerId] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Followers_FollowingId",
                schema: "dbo",
                table: "Followers",
                sql: "[FollowingId] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Id",
                schema: "dbo",
                table: "Clients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                schema: "dbo",
                table: "Clients",
                column: "Name");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Clients_Id",
                schema: "dbo",
                table: "Clients",
                sql: "[Id] > 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Followers_FollowerId",
                schema: "dbo",
                table: "Followers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Followers_FollowingId",
                schema: "dbo",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Id",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Name",
                schema: "dbo",
                table: "Clients");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Clients_Id",
                schema: "dbo",
                table: "Clients");
        }
    }
}
