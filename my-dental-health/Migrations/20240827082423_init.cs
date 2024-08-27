using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace my_dental_health.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagetPeriodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagetPeriodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetPiroity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetPiroity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthdayDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetPiroityId = table.Column<int>(type: "int", nullable: false),
                    PeriodTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TagetPeriodTypeId = table.Column<int>(type: "int", nullable: false),
                    PeriodLength = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Targets_TagetPeriodTypes_TagetPeriodTypeId",
                        column: x => x.TagetPeriodTypeId,
                        principalTable: "TagetPeriodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Targets_TargetPiroity_TargetPiroityId",
                        column: x => x.TargetPiroityId,
                        principalTable: "TargetPiroity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Targets_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookieHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUserRole",
                columns: table => new
                {
                    UserRolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserRole", x => new { x.UserRolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserUserRole_UserRoles_UserRolesId",
                        column: x => x.UserRolesId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserRole_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    Second = table.Column<int>(type: "int", nullable: false),
                    ImgHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetStatus_Targets_TargetsId",
                        column: x => x.TargetsId,
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Targets_TagetPeriodTypeId",
                table: "Targets",
                column: "TagetPeriodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_TargetPiroityId",
                table: "Targets",
                column: "TargetPiroityId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_UsersId",
                table: "Targets",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetStatus_TargetsId",
                table: "TargetStatus",
                column: "TargetsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UsersId",
                table: "UserLogins",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRole_UsersId",
                table: "UserUserRole",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TargetStatus");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserUserRole");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "TagetPeriodTypes");

            migrationBuilder.DropTable(
                name: "TargetPiroity");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
