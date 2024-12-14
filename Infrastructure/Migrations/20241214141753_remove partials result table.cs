using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TibberRobot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removepartialsresulttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartialResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartialResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartialResults", x => x.Id);
                });
        }
    }
}
