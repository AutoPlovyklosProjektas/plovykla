using Microsoft.EntityFrameworkCore.Migrations;

namespace Plovykla.Migrations
{
    public partial class addmigrationatsiliepiaiUpdt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vartotojoId",
                table: "Atsiliepimais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atsiliepimais_vartotojoId",
                table: "Atsiliepimais",
                column: "vartotojoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atsiliepimais_Vartotojais_vartotojoId",
                table: "Atsiliepimais",
                column: "vartotojoId",
                principalTable: "Vartotojais",
                principalColumn: "vartotojoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atsiliepimais_Vartotojais_vartotojoId",
                table: "Atsiliepimais");

            migrationBuilder.DropIndex(
                name: "IX_Atsiliepimais_vartotojoId",
                table: "Atsiliepimais");

            migrationBuilder.DropColumn(
                name: "vartotojoId",
                table: "Atsiliepimais");
        }
    }
}
