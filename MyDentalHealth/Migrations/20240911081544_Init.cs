using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyDentalHealth.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetPeriodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetPeriodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetPiroities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetPiroities", x => x.Id);
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetPiroityId = table.Column<int>(type: "int", nullable: false),
                    PeriodTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetPeriodTypeId = table.Column<int>(type: "int", nullable: false),
                    PeriodLength = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Targets_TargetPeriodTypes_TargetPeriodTypeId",
                        column: x => x.TargetPeriodTypeId,
                        principalTable: "TargetPeriodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Targets_TargetPiroities_TargetPiroityId",
                        column: x => x.TargetPiroityId,
                        principalTable: "TargetPiroities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Targets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserRoles", x => new { x.UserId, x.UserRoleId });
                    table.ForeignKey(
                        name: "FK_UserUserRoles_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserRoles_Users_UserId",
                        column: x => x.UserId,
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
                    TargetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetStatus_Targets_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Advices",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Brushing your teeth twice a day with fluoride toothpaste helps remove plaque and bacteria, keeping your teeth and gums healthy.", "Brush Twice Daily" },
                    { 2, "Flossing once a day removes food particles and plaque from between teeth, areas a toothbrush can't reach, reducing the risk of gum disease and cavities.", "Floss Daily" },
                    { 3, "Mouthwash can help kill bacteria, freshen breath, and strengthen enamel, especially when using fluoride or antiseptic mouthwashes.", "Use Mouthwash" },
                    { 4, "Excess sugar in your diet fuels bacteria that produce acid, leading to tooth decay. Avoid sugary snacks and beverages, especially between meals.", "Limit Sugary Foods and Drinks" },
                    { 5, "Drinking water helps wash away food particles and bacteria, and staying hydrated ensures your mouth produces enough saliva to protect your teeth.", "Stay Hydrated" },
                    { 6, "Regular dental check-ups and cleanings (every 6 months) allow for early detection of problems and professional plaque removal.", "Visit Your Dentist Regularly" },
                    { 7, "Smoking and using tobacco can lead to gum disease, tooth decay, and even oral cancer. Avoiding these products is key to long-term oral health.", "Don’t Use Tobacco Products" },
                    { 8, "A soft-bristle toothbrush is gentle on your gums and enamel, reducing the risk of erosion or irritation. Replace your toothbrush every 3-4 months.", "Use a Soft-Bristle Toothbrush" },
                    { 9, "Foods rich in calcium, vitamin D, and phosphorus help strengthen teeth and bones, while crunchy fruits and vegetables stimulate saliva production.", "Eat a Balanced Diet" },
                    { 10, "If you play contact sports, wearing a mouthguard helps protect your teeth from injury or trauma, reducing the risk of chipped or broken teeth.", "Wear a Mouthguard for Sports" }
                });

            migrationBuilder.InsertData(
                table: "TargetPeriodTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Day" },
                    { 2, "Week" },
                    { 3, "Month" },
                    { 4, "Year" }
                });

            migrationBuilder.InsertData(
                table: "TargetPiroities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "High" },
                    { 2, "Medium" },
                    { 3, "Low" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthdayDate", "Email", "Name", "Password", "Surname" },
                values: new object[] { 1, new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "admin", "YP50QG5/NT7ZefNQ8vu2ouhpCl+n0bDDKYPR2LP5X2c=", "admin" });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "Count", "Description", "Name", "PeriodLength", "PeriodTime", "TargetPeriodTypeId", "TargetPiroityId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "My Description", "My Target Test", 1, new DateTime(2024, 9, 11, 11, 15, 43, 871, DateTimeKind.Local).AddTicks(2786), 1, 1, 1 },
                    { 2, 10, "My Description", "My Target Test2", 2, new DateTime(2024, 7, 23, 11, 15, 43, 871, DateTimeKind.Local).AddTicks(2805), 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserUserRoles",
                columns: new[] { "UserId", "UserRoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TargetStatus",
                columns: new[] { "Id", "Attime", "ImgHash", "Minutes", "Second", "TargetId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 10, 11, 15, 43, 871, DateTimeKind.Local).AddTicks(2904), "", 0, 10, 1 },
                    { 2, new DateTime(2024, 8, 27, 11, 15, 43, 871, DateTimeKind.Local).AddTicks(2906), "", 0, 10, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Targets_TargetPeriodTypeId",
                table: "Targets",
                column: "TargetPeriodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_TargetPiroityId",
                table: "Targets",
                column: "TargetPiroityId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_UserId",
                table: "Targets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetStatus_TargetId",
                table: "TargetStatus",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRoles_UserRoleId",
                table: "UserUserRoles",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advices");

            migrationBuilder.DropTable(
                name: "TargetStatus");

            migrationBuilder.DropTable(
                name: "UserUserRoles");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "TargetPeriodTypes");

            migrationBuilder.DropTable(
                name: "TargetPiroities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
