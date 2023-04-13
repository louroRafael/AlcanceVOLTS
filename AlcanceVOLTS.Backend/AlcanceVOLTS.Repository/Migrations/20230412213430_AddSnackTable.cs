using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlcanceVOLTS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddSnackTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Snack_EventUser_EventUserId",
                        column: x => x.EventUserId,
                        principalTable: "EventUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Snack_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snack_EventUserId",
                table: "Snack",
                column: "EventUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Snack_PeriodId",
                table: "Snack",
                column: "PeriodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snack");
        }
    }
}
