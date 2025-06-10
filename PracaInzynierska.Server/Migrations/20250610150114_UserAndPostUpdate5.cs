using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserAndPostUpdate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RateModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Username = table.Column<string>(type: "varchar(32)", nullable: false),
                    PostId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Rate = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateModel");
        }
    }
}
