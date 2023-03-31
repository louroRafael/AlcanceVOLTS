using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlcanceVOLTS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class EventUserAddCheckinFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Badge",
                table: "EventUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BadgeLabel",
                table: "EventUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "WalkieTalkie",
                table: "EventUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WalkieTalkieNumber",
                table: "EventUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Wristband",
                table: "EventUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Badge",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "BadgeLabel",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "WalkieTalkie",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "WalkieTalkieNumber",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "Wristband",
                table: "EventUser");
        }
    }
}
