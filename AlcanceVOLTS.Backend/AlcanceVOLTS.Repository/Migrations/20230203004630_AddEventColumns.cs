using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlcanceVOLTS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddEventColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodsQuantity",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Tshirt",
                table: "Event",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodsQuantity",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Tshirt",
                table: "Event");
        }
    }
}
