using Microsoft.EntityFrameworkCore.Migrations;

namespace Interlogica.Pastry.BackEnd.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSpoiled",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MeasureUnit",
                table: "Ingredients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<bool>(
                name: "IsSpoiled",
                table: "Confectioneries",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
