using Microsoft.EntityFrameworkCore.Migrations;

namespace Interlogica.Pastry.BackEnd.Migrations
{
    public partial class RefactorII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfectioneryIngredient_Confectioneries_ConfectioneryId",
                table: "ConfectioneryIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfectioneryIngredient",
                table: "ConfectioneryIngredient");

            migrationBuilder.DropIndex(
                name: "IX_ConfectioneryIngredient_ConfectioneryId",
                table: "ConfectioneryIngredient");

            migrationBuilder.DropColumn(
                name: "ConfectoneryId",
                table: "ConfectioneryIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "ConfectioneryId",
                table: "ConfectioneryIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfectioneryIngredient",
                table: "ConfectioneryIngredient",
                columns: new[] { "ConfectioneryId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConfectioneryIngredient_Confectioneries_ConfectioneryId",
                table: "ConfectioneryIngredient",
                column: "ConfectioneryId",
                principalTable: "Confectioneries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfectioneryIngredient_Confectioneries_ConfectioneryId",
                table: "ConfectioneryIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfectioneryIngredient",
                table: "ConfectioneryIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "ConfectioneryId",
                table: "ConfectioneryIngredient",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ConfectoneryId",
                table: "ConfectioneryIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfectioneryIngredient",
                table: "ConfectioneryIngredient",
                columns: new[] { "ConfectoneryId", "IngredientId" });

            migrationBuilder.CreateIndex(
                name: "IX_ConfectioneryIngredient_ConfectioneryId",
                table: "ConfectioneryIngredient",
                column: "ConfectioneryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfectioneryIngredient_Confectioneries_ConfectioneryId",
                table: "ConfectioneryIngredient",
                column: "ConfectioneryId",
                principalTable: "Confectioneries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
