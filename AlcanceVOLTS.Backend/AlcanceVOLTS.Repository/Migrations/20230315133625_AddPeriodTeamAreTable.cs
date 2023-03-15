using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlcanceVOLTS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddPeriodTeamAreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PeriodId",
                table: "TeamArea",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TeamArea_PeriodId",
                table: "TeamArea",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamArea_Period_PeriodId",
                table: "TeamArea",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamArea_Period_PeriodId",
                table: "TeamArea");

            migrationBuilder.DropIndex(
                name: "IX_TeamArea_PeriodId",
                table: "TeamArea");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "TeamArea");
        }
    }
}
