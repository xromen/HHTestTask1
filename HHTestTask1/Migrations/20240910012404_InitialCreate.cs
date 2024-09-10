using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HHTestTask1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        private static Random rnd = new Random();
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    First_Name = table.Column<string>(type: "text", nullable: false),
                    Second_Name = table.Column<string>(type: "text", nullable: false),
                    Last_Login = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            Guid maximId = Guid.NewGuid();
            Guid ivanId = Guid.NewGuid();
            Guid petyaId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Users",
                columns: ["Id", "First_Name", "Second_Name", "Last_Login"],
                values: new object[,]
                {
                    { maximId, "Максим", "Казеев", DateTime.UtcNow },
                    { ivanId, "Иван", "Петров", DateTime.UtcNow.AddMinutes(-10) },
                    { petyaId, "Петр", "Иванов", DateTime.UtcNow.AddMinutes(-15) },
                }
                );

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count_Sign_In = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignInHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignInHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignInHistory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SignInHistory",
                columns: ["Id", "UserId", "Login"],
                values: new object[,]
                {
                    { Guid.NewGuid(), maximId, DateTime.UtcNow.AddMinutes(-rnd.Next(1, 120)) },
                    { Guid.NewGuid(), maximId, DateTime.UtcNow.AddMinutes(-rnd.Next(1, 120)) },
                    { Guid.NewGuid(), maximId, DateTime.UtcNow.AddMinutes(-rnd.Next(1, 120)) },
                    { Guid.NewGuid(), ivanId, DateTime.UtcNow.AddMinutes(-rnd.Next(1, 120)) },
                    { Guid.NewGuid(), ivanId, DateTime.UtcNow.AddMinutes(-rnd.Next(1, 120)) },
                    { Guid.NewGuid(), ivanId, DateTime.UtcNow.AddMinutes(-rnd.Next(1, 120)) },
                    { Guid.NewGuid(), petyaId, DateTime.UtcNow.AddMinutes(-rnd.Next(1, 120)) },
                    { Guid.NewGuid(), petyaId, DateTime.UtcNow.AddMinutes(-rnd.Next(1, 120)) },
                    { Guid.NewGuid(), petyaId, DateTime.UtcNow.AddMinutes(-rnd.Next(1, 120)) },
                }
                );

            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ResultId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queries_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Queries_ResultId",
                table: "Queries",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SignInHistory_UserId",
                table: "SignInHistory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Queries");

            migrationBuilder.DropTable(
                name: "SignInHistory");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
