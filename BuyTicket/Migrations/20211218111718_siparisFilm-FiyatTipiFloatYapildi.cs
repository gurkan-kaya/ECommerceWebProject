using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyTicket.Migrations
{
    public partial class siparisFilmFiyatTipiFloatYapildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Fiyat",
                table: "SiparisFilmler",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Fiyat",
                table: "SiparisFilmler",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
