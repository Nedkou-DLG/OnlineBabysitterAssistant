using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBabysitterAssistant.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "babysitters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_babysitters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_babysitters_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "parents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parents_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BabysitterRecordParentRecord",
                columns: table => new
                {
                    BabysittersId = table.Column<int>(type: "int", nullable: false),
                    ParentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabysitterRecordParentRecord", x => new { x.BabysittersId, x.ParentsId });
                    table.ForeignKey(
                        name: "FK_BabysitterRecordParentRecord_babysitters_BabysittersId",
                        column: x => x.BabysittersId,
                        principalTable: "babysitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BabysitterRecordParentRecord_parents_ParentsId",
                        column: x => x.ParentsId,
                        principalTable: "parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    BabysitterId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_children_babysitters_BabysitterId",
                        column: x => x.BabysitterId,
                        principalTable: "babysitters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_children_parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_activites_children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activites_ChildId",
                table: "activites",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_BabysitterRecordParentRecord_ParentsId",
                table: "BabysitterRecordParentRecord",
                column: "ParentsId");

            migrationBuilder.CreateIndex(
                name: "IX_children_BabysitterId",
                table: "children",
                column: "BabysitterId");

            migrationBuilder.CreateIndex(
                name: "IX_children_ParentId",
                table: "children",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activites");

            migrationBuilder.DropTable(
                name: "BabysitterRecordParentRecord");

            migrationBuilder.DropTable(
                name: "children");

            migrationBuilder.DropTable(
                name: "babysitters");

            migrationBuilder.DropTable(
                name: "parents");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
