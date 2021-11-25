using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyTicket.Migrations
{
    public partial class duzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oyuncular",
                columns: table => new
                {
                    OyuncuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OyuncuFotografi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OyuncuAdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OyuncuHakkinda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyuncular", x => x.OyuncuId);
                });

            migrationBuilder.CreateTable(
                name: "Sinemalar",
                columns: table => new
                {
                    SinemaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinemaFotografi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinemaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinemaHakkinda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinemalar", x => x.SinemaId);
                });

            migrationBuilder.CreateTable(
                name: "Yonetmenler",
                columns: table => new
                {
                    YonetmenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YonetmenFotografi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YonetmenAdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YonetmenHakkinda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yonetmenler", x => x.YonetmenId);
                });

            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmHakkinda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmBaslamaSaati1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmBaslamaSaati2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmBaslamaSaati3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmFotografi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmKategorisi = table.Column<int>(type: "int", nullable: false),
                    FilmUcreti = table.Column<float>(type: "real", nullable: false),
                    SinemaId = table.Column<int>(type: "int", nullable: false),
                    YonetmenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_Filmler_Sinemalar_SinemaId",
                        column: x => x.SinemaId,
                        principalTable: "Sinemalar",
                        principalColumn: "SinemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filmler_Yonetmenler_YonetmenId",
                        column: x => x.YonetmenId,
                        principalTable: "Yonetmenler",
                        principalColumn: "YonetmenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmlerOyuncular",
                columns: table => new
                {
                    OyuncuId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmlerOyuncular", x => new { x.OyuncuId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_FilmlerOyuncular_Filmler_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmler",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmlerOyuncular_Oyuncular_OyuncuId",
                        column: x => x.OyuncuId,
                        principalTable: "Oyuncular",
                        principalColumn: "OyuncuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmler_SinemaId",
                table: "Filmler",
                column: "SinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmler_YonetmenId",
                table: "Filmler",
                column: "YonetmenId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmlerOyuncular_FilmId",
                table: "FilmlerOyuncular",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmlerOyuncular");

            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Oyuncular");

            migrationBuilder.DropTable(
                name: "Sinemalar");

            migrationBuilder.DropTable(
                name: "Yonetmenler");
        }
    }
}
