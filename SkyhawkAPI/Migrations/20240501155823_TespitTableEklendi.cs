using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyhawkAPI.Migrations
{
    /// <inheritdoc />
    public partial class TespitTableEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tespitler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XKoordinatı = table.Column<double>(type: "float", nullable: false),
                    Ykoordinatı = table.Column<double>(type: "float", nullable: false),
                    TespitZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TespitFotografi = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tespitler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tespitler");
        }
    }
}
