using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HHTestTask1.Migrations
{
    /// <inheritdoc />
    public partial class AddStartTimeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Queries",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Queries");
        }
    }
}
