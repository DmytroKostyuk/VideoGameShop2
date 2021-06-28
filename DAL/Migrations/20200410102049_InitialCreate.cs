using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGameShop2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id_Genre = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id_Genre);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id_Publisher = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id_Publisher);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_User = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<double>(nullable: false),
                    Nickname = table.Column<string>(maxLength: 30, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id_Dev = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Id_Publisher = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id_Dev);
                    table.ForeignKey(
                        name: "FK_Developers_Publishers_Id_Publisher",
                        column: x => x.Id_Publisher,
                        principalTable: "Publishers",
                        principalColumn: "Id_Publisher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id_Game = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Id_Dev = table.Column<int>(nullable: false),
                    Id_Genre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id_Game);
                    table.ForeignKey(
                        name: "FK_Games_Developers_Id_Dev",
                        column: x => x.Id_Dev,
                        principalTable: "Developers",
                        principalColumn: "Id_Dev",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Genres_Id_Genre",
                        column: x => x.Id_Genre,
                        principalTable: "Genres",
                        principalColumn: "Id_Genre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBoughts",
                columns: table => new
                {
                    Id_Purchase = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_User = table.Column<int>(nullable: false),
                    Id_Game = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBoughts", x => x.Id_Purchase);
                    table.ForeignKey(
                        name: "FK_UserBoughts_Games_Id_Game",
                        column: x => x.Id_Game,
                        principalTable: "Games",
                        principalColumn: "Id_Game",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBoughts_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Developers_Id_Publisher",
                table: "Developers",
                column: "Id_Publisher");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Id_Dev",
                table: "Games",
                column: "Id_Dev");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Id_Genre",
                table: "Games",
                column: "Id_Genre");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoughts_Id_Game",
                table: "UserBoughts",
                column: "Id_Game");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoughts_Id_User",
                table: "UserBoughts",
                column: "Id_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBoughts");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
