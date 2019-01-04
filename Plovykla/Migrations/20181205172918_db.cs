using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plovykla.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Busenos",
                columns: table => new
                {
                    busenosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    busena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busenos", x => x.busenosId);
                });

            migrationBuilder.CreateTable(
                name: "Kategorijas",
                columns: table => new
                {
                    kategorijosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    kategorijosPavadinimas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorijas", x => x.kategorijosId);
                });

            migrationBuilder.CreateTable(
                name: "Medziagos",
                columns: table => new
                {
                    medziagosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    medziaga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medziagos", x => x.medziagosId);
                });

            migrationBuilder.CreateTable(
                name: "Paslaugas",
                columns: table => new
                {
                    paslaugosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    paslaugosKaina = table.Column<double>(nullable: false),
                    paslaugosPavadinimas = table.Column<string>(nullable: true),
                    paslaugosAprasymas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paslaugas", x => x.paslaugosId);
                });

            migrationBuilder.CreateTable(
                name: "Vartotojais",
                columns: table => new
                {
                    vartotojoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    vardas = table.Column<string>(nullable: true),
                    pavarde = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    kategorijosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vartotojais", x => x.vartotojoId);
                    table.ForeignKey(
                        name: "FK_Vartotojais_Kategorijas_kategorijosId",
                        column: x => x.kategorijosId,
                        principalTable: "Kategorijas",
                        principalColumn: "kategorijosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trukumais",
                columns: table => new
                {
                    trukumoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    medziagosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trukumais", x => x.trukumoId);
                    table.ForeignKey(
                        name: "FK_Trukumais_Medziagos_medziagosId",
                        column: x => x.medziagosId,
                        principalTable: "Medziagos",
                        principalColumn: "medziagosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atsiliepimais",
                columns: table => new
                {
                    atsiliepimoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    atsiliepimas = table.Column<string>(nullable: true),
                    paslaugosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atsiliepimais", x => x.atsiliepimoId);
                    table.ForeignKey(
                        name: "FK_Atsiliepimais_Paslaugas_paslaugosId",
                        column: x => x.paslaugosId,
                        principalTable: "Paslaugas",
                        principalColumn: "paslaugosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uzsakymas",
                columns: table => new
                {
                    uzsakymoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    uzsakymo_Data = table.Column<DateTime>(nullable: false),
                    uzsakymoKaina = table.Column<double>(nullable: false),
                    paslaugosId = table.Column<int>(nullable: false),
                    darbuotojoId = table.Column<int>(nullable: true),
                    klientoId = table.Column<int>(nullable: true),
                    busenosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzsakymas", x => x.uzsakymoId);
                    table.ForeignKey(
                        name: "FK_Uzsakymas_Busenos_busenosId",
                        column: x => x.busenosId,
                        principalTable: "Busenos",
                        principalColumn: "busenosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uzsakymas_Vartotojais_darbuotojoId",
                        column: x => x.darbuotojoId,
                        principalTable: "Vartotojais",
                        principalColumn: "vartotojoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uzsakymas_Vartotojais_klientoId",
                        column: x => x.klientoId,
                        principalTable: "Vartotojais",
                        principalColumn: "vartotojoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uzsakymas_Paslaugas_paslaugosId",
                        column: x => x.paslaugosId,
                        principalTable: "Paslaugas",
                        principalColumn: "paslaugosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baudos",
                columns: table => new
                {
                    baudosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    baudosAprasymas = table.Column<string>(nullable: true),
                    nuostolis = table.Column<double>(nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    vartotojoId = table.Column<int>(nullable: false),
                    uzsakymoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baudos", x => x.baudosId);
                    table.ForeignKey(
                        name: "FK_Baudos_Uzsakymas_uzsakymoId",
                        column: x => x.uzsakymoId,
                        principalTable: "Uzsakymas",
                        principalColumn: "uzsakymoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baudos_Vartotojais_vartotojoId",
                        column: x => x.vartotojoId,
                        principalTable: "Vartotojais",
                        principalColumn: "vartotojoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atsiliepimais_paslaugosId",
                table: "Atsiliepimais",
                column: "paslaugosId");

            migrationBuilder.CreateIndex(
                name: "IX_Baudos_uzsakymoId",
                table: "Baudos",
                column: "uzsakymoId");

            migrationBuilder.CreateIndex(
                name: "IX_Baudos_vartotojoId",
                table: "Baudos",
                column: "vartotojoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trukumais_medziagosId",
                table: "Trukumais",
                column: "medziagosId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzsakymas_busenosId",
                table: "Uzsakymas",
                column: "busenosId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzsakymas_darbuotojoId",
                table: "Uzsakymas",
                column: "darbuotojoId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzsakymas_klientoId",
                table: "Uzsakymas",
                column: "klientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzsakymas_paslaugosId",
                table: "Uzsakymas",
                column: "paslaugosId");

            migrationBuilder.CreateIndex(
                name: "IX_Vartotojais_kategorijosId",
                table: "Vartotojais",
                column: "kategorijosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atsiliepimais");

            migrationBuilder.DropTable(
                name: "Baudos");

            migrationBuilder.DropTable(
                name: "Trukumais");

            migrationBuilder.DropTable(
                name: "Uzsakymas");

            migrationBuilder.DropTable(
                name: "Medziagos");

            migrationBuilder.DropTable(
                name: "Busenos");

            migrationBuilder.DropTable(
                name: "Vartotojais");

            migrationBuilder.DropTable(
                name: "Paslaugas");

            migrationBuilder.DropTable(
                name: "Kategorijas");
        }
    }
}
