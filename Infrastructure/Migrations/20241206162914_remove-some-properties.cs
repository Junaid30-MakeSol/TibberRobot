using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TibberRobot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removesomeproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "ExecutionRecords");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExecutionRecords");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ExecutionRecords");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ExecutionRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "ExecutionRecords",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExecutionRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "ExecutionRecords",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ExecutionRecords",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
