using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetmealSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBreedNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Breeds");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Breeds",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameZhTw",
                table: "Breeds",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "NameZhTw",
                table: "Breeds");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Breeds",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
