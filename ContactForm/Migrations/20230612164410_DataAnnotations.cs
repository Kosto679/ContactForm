using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactForm.Migrations
{
    /// <inheritdoc />
    public partial class DataAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persondets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persondets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phonedets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonedets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phonedets_Persondets_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Persondets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phonedets_CustomerId",
                table: "Phonedets",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phonedets");

            migrationBuilder.DropTable(
                name: "Persondets");
        }
    }
}
