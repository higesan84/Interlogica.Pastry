using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Interlogica.Pastry.BackEnd.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectioneries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    IsSpoiled = table.Column<bool>(type: "INTEGER", nullable: false),
                    BakingDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectioneries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    MeasureUnit = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfectioneryIngredient",
                columns: table => new
                {
                    ConfectoneryId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfectioneryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfectioneryIngredient", x => new { x.ConfectoneryId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_ConfectioneryIngredient_Confectioneries_ConfectioneryId",
                        column: x => x.ConfectioneryId,
                        principalTable: "Confectioneries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfectioneryIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfectioneryIngredient_ConfectioneryId",
                table: "ConfectioneryIngredient",
                column: "ConfectioneryId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfectioneryIngredient_IngredientId",
                table: "ConfectioneryIngredient",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfectioneryIngredient");

            migrationBuilder.DropTable(
                name: "Confectioneries");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
