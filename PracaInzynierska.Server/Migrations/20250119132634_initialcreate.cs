using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountModel",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(32)", nullable: false),
                    Score = table.Column<string>(type: "varchar(10)", nullable: false),
                    PostsCount = table.Column<string>(type: "varchar(8)", nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountModel", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "BaitModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(36)", nullable: false),
                    Size = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaitModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroundbaitModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundbaitModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MethodModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodModel", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "IngredientModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(36)", nullable: false),
                    GroundbaitModelId = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientModel_GroundbaitModel_GroundbaitModelId",
                        column: x => x.GroundbaitModelId,
                        principalTable: "GroundbaitModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaitModelMethodModel",
                columns: table => new
                {
                    BaitId = table.Column<string>(type: "varchar(36)", nullable: false),
                    MethodsName = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaitModelMethodModel", x => new { x.BaitId, x.MethodsName });
                    table.ForeignKey(
                        name: "FK_BaitModelMethodModel_BaitModel_BaitId",
                        column: x => x.BaitId,
                        principalTable: "BaitModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaitModelMethodModel_MethodModel_MethodsName",
                        column: x => x.MethodsName,
                        principalTable: "MethodModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FishModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(36)", nullable: false),
                    MethodModelName = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishModel", x => x.Name);
                    table.ForeignKey(
                        name: "FK_FishModel_MethodModel_MethodModelName",
                        column: x => x.MethodModelName,
                        principalTable: "MethodModel",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "GroundbaitModelMethodModel",
                columns: table => new
                {
                    GroundbaitId = table.Column<string>(type: "varchar(36)", nullable: false),
                    MethodsName = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundbaitModelMethodModel", x => new { x.GroundbaitId, x.MethodsName });
                    table.ForeignKey(
                        name: "FK_GroundbaitModelMethodModel_GroundbaitModel_GroundbaitId",
                        column: x => x.GroundbaitId,
                        principalTable: "GroundbaitModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroundbaitModelMethodModel_MethodModel_MethodsName",
                        column: x => x.MethodsName,
                        principalTable: "MethodModel",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapModel",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(36)", nullable: false),
                    Fishes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    X = table.Column<string>(type: "varchar(4)", nullable: false),
                    Y = table.Column<string>(type: "varchar(4)", nullable: false),
                    FishModelName = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapModel", x => x.Name);
                    table.ForeignKey(
                        name: "FK_MapModel_FishModel_FishModelName",
                        column: x => x.FishModelName,
                        principalTable: "FishModel",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "PostModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    userID = table.Column<string>(type: "varchar(36)", nullable: false),
                    fishName = table.Column<string>(type: "varchar(36)", nullable: true),
                    rate = table.Column<string>(type: "varchar(8)", nullable: false),
                    AccountModelUsername = table.Column<string>(type: "varchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostModel_AccountModel_AccountModelUsername",
                        column: x => x.AccountModelUsername,
                        principalTable: "AccountModel",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_PostModel_FishModel_fishName",
                        column: x => x.fishName,
                        principalTable: "FishModel",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "SpotModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    X = table.Column<string>(type: "varchar(4)", nullable: false),
                    Y = table.Column<string>(type: "varchar(4)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "varchar(4)", nullable: false),
                    MapName = table.Column<string>(type: "varchar(36)", nullable: true),
                    FishModelName = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpotModel_FishModel_FishModelName",
                        column: x => x.FishModelName,
                        principalTable: "FishModel",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_SpotModel_MapModel_MapName",
                        column: x => x.MapName,
                        principalTable: "MapModel",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaitModelMethodModel_MethodsName",
                table: "BaitModelMethodModel",
                column: "MethodsName");

            migrationBuilder.CreateIndex(
                name: "IX_FishModel_MethodModelName",
                table: "FishModel",
                column: "MethodModelName");

            migrationBuilder.CreateIndex(
                name: "IX_GroundbaitModelMethodModel_MethodsName",
                table: "GroundbaitModelMethodModel",
                column: "MethodsName");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientModel_GroundbaitModelId",
                table: "IngredientModel",
                column: "GroundbaitModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MapModel_FishModelName",
                table: "MapModel",
                column: "FishModelName");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_AccountModelUsername",
                table: "PostModel",
                column: "AccountModelUsername");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_fishName",
                table: "PostModel",
                column: "fishName");

            migrationBuilder.CreateIndex(
                name: "IX_SpotModel_FishModelName",
                table: "SpotModel",
                column: "FishModelName");

            migrationBuilder.CreateIndex(
                name: "IX_SpotModel_MapName",
                table: "SpotModel",
                column: "MapName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaitModelMethodModel");

            migrationBuilder.DropTable(
                name: "GroundbaitModelMethodModel");

            migrationBuilder.DropTable(
                name: "IngredientModel");

            migrationBuilder.DropTable(
                name: "PostModel");

            migrationBuilder.DropTable(
                name: "SpotModel");

            migrationBuilder.DropTable(
                name: "BaitModel");

            migrationBuilder.DropTable(
                name: "GroundbaitModel");

            migrationBuilder.DropTable(
                name: "AccountModel");

            migrationBuilder.DropTable(
                name: "MapModel");

            migrationBuilder.DropTable(
                name: "FishModel");

            migrationBuilder.DropTable(
                name: "MethodModel");
        }
    }
}
