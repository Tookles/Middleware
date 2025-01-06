using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiddlewareApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventurers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FightingClass = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    XP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventurers", x => x.Id);
                    table.CheckConstraint("CK_Adventurers_Level_Range", "[Level] BETWEEN 1 AND 2147483647");
                    table.CheckConstraint("CK_Adventurers_XP_Range", "[XP] BETWEEN 0 AND 2147483647");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adventurers");
        }
    }
}
