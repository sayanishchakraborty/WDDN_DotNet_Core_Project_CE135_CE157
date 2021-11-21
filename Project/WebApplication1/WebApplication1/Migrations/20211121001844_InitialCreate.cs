using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Department",
                columns: table => new
                {
                    DepID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Department", x => x.DepID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DepID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Subject",
                columns: table => new
                {
                    SubID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Subject", x => x.SubID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Department");

            migrationBuilder.DropTable(
                name: "tbl_Student");

            migrationBuilder.DropTable(
                name: "tbl_Subject");
        }
    }
}
