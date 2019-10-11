using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterList",
                columns: table => new
                {
                    CharacterListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterList", x => x.CharacterListId);
                    table.ForeignKey(
                        name: "FK_CharacterList_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TibiaCharacter",
                columns: table => new
                {
                    TibiaCharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Vocation = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    World = table.Column<string>(nullable: true),
                    PVPType = table.Column<string>(nullable: true),
                    CharacterListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TibiaCharacter", x => x.TibiaCharacterId);
                    table.ForeignKey(
                        name: "FK_TibiaCharacter_CharacterList_CharacterListId",
                        column: x => x.CharacterListId,
                        principalTable: "CharacterList",
                        principalColumn: "CharacterListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterList_AccountId",
                table: "CharacterList",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TibiaCharacter_CharacterListId",
                table: "TibiaCharacter",
                column: "CharacterListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TibiaCharacter");

            migrationBuilder.DropTable(
                name: "CharacterList");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
