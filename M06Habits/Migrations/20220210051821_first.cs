using Microsoft.EntityFrameworkCore.Migrations;

namespace M06Habits.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    DataId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    task = table.Column<string>(nullable: false),
                    due_date = table.Column<string>(nullable: true),
                    quadrant = table.Column<int>(nullable: false),
                    category = table.Column<string>(nullable: true),
                    completed = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.DataId);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "DataId", "CategoryID", "category", "completed", "due_date", "quadrant", "task" },
                values: new object[] { 2, 1, null, false, "Feb 20, 2022", 2, "Pickleball" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "DataId", "CategoryID", "category", "completed", "due_date", "quadrant", "task" },
                values: new object[] { 4, 1, null, false, "Feb 28, 2022", 4, "Check Insta" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "DataId", "CategoryID", "category", "completed", "due_date", "quadrant", "task" },
                values: new object[] { 1, 2, null, false, "Feb 15, 2022", 1, "Midterm" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "DataId", "CategoryID", "category", "completed", "due_date", "quadrant", "task" },
                values: new object[] { 3, 3, null, true, "Feb 26, 2022", 3, "Interuption" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryID",
                table: "Responses",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
