using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlcanceVOLTS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FixTeamAreaNullableTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamArea_Area_AreaId",
                table: "TeamArea");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamArea_Team_TeamId",
                table: "TeamArea");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "TeamArea",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaId",
                table: "TeamArea",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamArea_Area_AreaId",
                table: "TeamArea",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamArea_Team_TeamId",
                table: "TeamArea",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamArea_Area_AreaId",
                table: "TeamArea");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamArea_Team_TeamId",
                table: "TeamArea");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "TeamArea",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaId",
                table: "TeamArea",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamArea_Area_AreaId",
                table: "TeamArea",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamArea_Team_TeamId",
                table: "TeamArea",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");
        }
    }
}
