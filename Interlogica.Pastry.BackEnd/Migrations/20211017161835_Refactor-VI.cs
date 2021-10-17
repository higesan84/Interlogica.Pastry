using Microsoft.EntityFrameworkCore.Migrations;

namespace Interlogica.Pastry.BackEnd.Migrations
{
    public partial class RefactorVI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureUnit",
                table: "ConfectioneryIngredient");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ConfectioneryIngredient");

            migrationBuilder.AlterColumn<string>(
                name: "MeasureUnit",
                table: "Ingredients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "Confectioneries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "Confectioneries");

            migrationBuilder.AlterColumn<int>(
                name: "MeasureUnit",
                table: "Ingredients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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
    }
}
