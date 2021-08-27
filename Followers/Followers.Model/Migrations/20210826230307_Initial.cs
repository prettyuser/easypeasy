using Microsoft.EntityFrameworkCore.Migrations;

namespace Followers.Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.CheckConstraint("CK_Clients_Id", "[Id] > 0");
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    SubscriberId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubscribingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => new { x.SubscriberId, x.SubscribingId });
                    table.CheckConstraint("CK_Subscribers", "[SubscriberId] <> [SubscribingId]");
                    table.CheckConstraint("CK_Subscribers_SubscriberId", "[SubscriberId] > 0");
                    table.CheckConstraint("CK_Subscribers_SubscribingId", "[SubscribingId] > 0");
                    table.ForeignKey(
                        name: "FK_Subscribers_Clients_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscribers_Clients_SubscribingId",
                        column: x => x.SubscribingId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Id",
                table: "Clients",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                table: "Clients",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_SubscribingId",
                table: "Subscribers",
                column: "SubscribingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
