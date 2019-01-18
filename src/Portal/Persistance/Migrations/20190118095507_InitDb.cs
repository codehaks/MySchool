using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Persistance.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    Teacher = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false),
                    SureName = table.Column<string>(maxLength: 20, nullable: false),
                    GivenName = table.Column<string>(maxLength: 20, nullable: false),
                    Age = table.Column<byte>(nullable: false),
                    GPA = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => new { x.ClassId, x.SureName });
                    table.ForeignKey(
                        name: "FK_Student_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Class");
        }
    }
}
