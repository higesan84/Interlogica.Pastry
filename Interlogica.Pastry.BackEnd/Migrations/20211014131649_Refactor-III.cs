using Microsoft.EntityFrameworkCore.Migrations;

namespace Interlogica.Pastry.BackEnd.Migrations
{
    public partial class RefactorIII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasureUnit",
                table: "ConfectioneryIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "ConfectioneryIngredient",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureUnit",
                table: "ConfectioneryIngredient");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ConfectioneryIngredient");
        }
    }
}
