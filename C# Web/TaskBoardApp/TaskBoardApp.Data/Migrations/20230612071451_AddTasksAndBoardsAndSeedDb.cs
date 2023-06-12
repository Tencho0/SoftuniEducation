using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddTasksAndBoardsAndSeedDb : Migration
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("b203ac3c-fb6b-42c4-8129-adf126f35227"), 2, new DateTime(2023, 5, 12, 7, 14, 50, 161, DateTimeKind.Utc).AddTicks(7159), "Create Desktop client App for the RESTful TaskBoard service", "4aeb86e9-f3fe-4314-886b-fe757932b840", "Desktop Client App" },
                    { new Guid("d34dface-6e69-4ac9-a0e9-035ec6d2c064"), 1, new DateTime(2022, 11, 24, 7, 14, 50, 161, DateTimeKind.Utc).AddTicks(7088), "Implement better styling for all public pages", "4aeb86e9-f3fe-4314-886b-fe757932b840", "Improve CSS styles" },
                    { new Guid("d3e1a633-f464-45cb-8cb5-dc9a884e093b"), 1, new DateTime(2023, 1, 12, 7, 14, 50, 161, DateTimeKind.Utc).AddTicks(7145), "Create Android client App for the RESTful TaskBoard service", "0f8cb3b5-2f97-4444-a0c2-fdc027303b25", "Android Client App" },
                    { new Guid("d68936a7-66b3-48f8-946a-9e0d3d5dbde6"), 3, new DateTime(2022, 6, 12, 7, 14, 50, 161, DateTimeKind.Utc).AddTicks(7169), "Implement [Create Task] page for adding tasks", "4aeb86e9-f3fe-4314-886b-fe757932b840", "Create Tasks" }
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
        }
    }
}
