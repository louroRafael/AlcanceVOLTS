using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlcanceVOLTS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class EventUserAdditionalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Button",
                table: "EventUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TeamLeader",
                table: "EventUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tshirt",
                table: "EventUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TshirtSize",
                table: "EventUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Button",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "TeamLeader",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "Tshirt",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "TshirtSize",
                table: "EventUser");
        }
    }
}
