using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Web.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99a7ad7e-8514-4ab8-8c98-cfb3f61f1e10", 0, "dcae0a64-3b26-4611-8c26-93bb67c53b8a", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEGPh9Jk8IJ2W+1JN6qXLVoTBjvggUSd2WZp9EXd8tkhI68o0lYqD9xqnIRAJRBSXSQ==", null, false, "cbd6e610-3afb-43a3-8396-09012e68ea58", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 22, 1, 40, 2, 440, DateTimeKind.Local).AddTicks(8879), "Implement better styling for all public pages", "99a7ad7e-8514-4ab8-8c98-cfb3f61f1e10", "Improve CSS files" },
                    { 2, 1, new DateTime(2023, 1, 10, 1, 40, 2, 440, DateTimeKind.Local).AddTicks(8915), "Create Android client app for the TaskBoard RESTful API", "99a7ad7e-8514-4ab8-8c98-cfb3f61f1e10", "Android Client App" },
                    { 3, 2, new DateTime(2023, 5, 10, 1, 40, 2, 440, DateTimeKind.Local).AddTicks(8919), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "99a7ad7e-8514-4ab8-8c98-cfb3f61f1e10", "Dektop Client App" },
                    { 4, 3, new DateTime(2022, 6, 10, 1, 40, 2, 440, DateTimeKind.Local).AddTicks(8922), "Implement [Create Task] for adding new tasks", "99a7ad7e-8514-4ab8-8c98-cfb3f61f1e10", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99a7ad7e-8514-4ab8-8c98-cfb3f61f1e10");
        }
    }
}
