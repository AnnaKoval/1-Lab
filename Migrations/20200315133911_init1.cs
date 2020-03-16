using Microsoft.EntityFrameworkCore.Migrations;

namespace Ad4You.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sign = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rubric",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rubric", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: false),
                    rubricid = table.Column<int>(nullable: false),
                    cityid = table.Column<int>(nullable: true),
                    price = table.Column<long>(nullable: true),
                    currencyid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ad", x => x.id);
                    table.ForeignKey(
                        name: "FK_ad_city_cityid",
                        column: x => x.cityid,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ad_currency_currencyid",
                        column: x => x.currencyid,
                        principalTable: "currency",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ad_rubric_rubricid",
                        column: x => x.rubricid,
                        principalTable: "rubric",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ad_cityid",
                table: "ad",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_ad_currencyid",
                table: "ad",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_ad_rubricid",
                table: "ad",
                column: "rubricid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ad");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "rubric");
        }
    }
}
