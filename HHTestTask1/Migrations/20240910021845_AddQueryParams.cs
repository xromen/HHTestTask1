using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HHTestTask1.Migrations
{
    /// <inheritdoc />
    public partial class AddQueryParams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Queries",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: null);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Queries",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: null);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Queries",
                type: "uuid",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Queries_UserId",
                table: "Queries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Queries_Users_UserId",
                table: "Queries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Queries_Users_UserId",
                table: "Queries");

            migrationBuilder.DropIndex(
                name: "IX_Queries_UserId",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Queries");
        }
    }
}
