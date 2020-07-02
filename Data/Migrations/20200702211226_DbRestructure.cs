using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DbRestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterList_Account_AccountId",
                table: "CharacterList");

            migrationBuilder.DropForeignKey(
                name: "FK_TibiaCharacter_CharacterList_CharacterListId",
                table: "TibiaCharacter");

            migrationBuilder.DropIndex(
                name: "IX_TibiaCharacter_CharacterListId",
                table: "TibiaCharacter");

            migrationBuilder.DropIndex(
                name: "IX_CharacterList_AccountId",
                table: "CharacterList");

            migrationBuilder.DropColumn(
                name: "CharacterListId",
                table: "TibiaCharacter");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "CharacterList");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "CharacterListId",
                table: "Account",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CharacterListRelation",
                columns: table => new
                {
                    TibiaCharacterId = table.Column<int>(nullable: false),
                    CharacterListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterListRelation", x => new { x.CharacterListId, x.TibiaCharacterId });
                    table.ForeignKey(
                        name: "FK_CharacterListRelation_CharacterList_CharacterListId",
                        column: x => x.CharacterListId,
                        principalTable: "CharacterList",
                        principalColumn: "CharacterListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterListRelation_TibiaCharacter_TibiaCharacterId",
                        column: x => x.TibiaCharacterId,
                        principalTable: "TibiaCharacter",
                        principalColumn: "TibiaCharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_CharacterListId",
                table: "Account",
                column: "CharacterListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterListRelation_TibiaCharacterId",
                table: "CharacterListRelation",
                column: "TibiaCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_CharacterList_CharacterListId",
                table: "Account",
                column: "CharacterListId",
                principalTable: "CharacterList",
                principalColumn: "CharacterListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_CharacterList_CharacterListId",
                table: "Account");

            migrationBuilder.DropTable(
                name: "CharacterListRelation");

            migrationBuilder.DropIndex(
                name: "IX_Account_CharacterListId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CharacterListId",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "CharacterListId",
                table: "TibiaCharacter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "CharacterList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TibiaCharacter_CharacterListId",
                table: "TibiaCharacter",
                column: "CharacterListId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterList_AccountId",
                table: "CharacterList",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterList_Account_AccountId",
                table: "CharacterList",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TibiaCharacter_CharacterList_CharacterListId",
                table: "TibiaCharacter",
                column: "CharacterListId",
                principalTable: "CharacterList",
                principalColumn: "CharacterListId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
