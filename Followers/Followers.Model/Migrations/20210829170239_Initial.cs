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
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubscribingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => new { x.ClientId, x.SubscribingId });
                    table.CheckConstraint("CK_Subscribers_NotSelfReferenceAllowed", "[ClientId] <> [SubscribingId]");
                    table.CheckConstraint("CK_Subscribers_Correct_ClientId", "[ClientId] > 0");
                    table.CheckConstraint("CK_Subscribers_Correct_SubscribingId", "[SubscribingId] > 0");
                    table.ForeignKey(
                        name: "FK_Subscribers_Clients_ClientId",
                        column: x => x.ClientId,
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

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 1, true, "Boris", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 2, true, "Pepa", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 3, true, "Anna", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 4, true, "Olga", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 5, true, "Diana", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 6, true, "Maria", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 7, true, "Stefano", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 8, true, "Roman", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 9, true, "Igor", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 10, true, "Vladislav", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 11, true, "Elena", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 12, true, "Jee", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 13, true, "Frantisek", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[] { 14, true, "Irina", null });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 2, 9 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 1, 9 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 9, 1 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 4, 8 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 7, 8 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 8, 3 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 2, 7 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 1, 7 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 1, 12 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 7, 6 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "ClientId", "SubscribingId" },
                values: new object[] { 1, 14 });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Id",
                table: "Clients",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                table: "Clients",
                column: "Name",
                unique: true);

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
