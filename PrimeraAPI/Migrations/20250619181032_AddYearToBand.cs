using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeraAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddYearToBand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Bands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Bands");
        }
    }
}
