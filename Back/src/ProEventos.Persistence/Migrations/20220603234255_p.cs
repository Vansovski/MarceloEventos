using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEventos.Persistence.Migrations
{
    public partial class p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocials_Eventos_EventoId",
                table: "RedesSocials");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocials_Palestrantes_PalestranteId",
                table: "RedesSocials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedesSocials",
                table: "RedesSocials");

            migrationBuilder.RenameTable(
                name: "RedesSocials",
                newName: "RedesSociais");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSocials_PalestranteId",
                table: "RedesSociais",
                newName: "IX_RedesSociais_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSocials_EventoId",
                table: "RedesSociais",
                newName: "IX_RedesSociais_EventoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedesSociais",
                table: "RedesSociais",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSociais_Eventos_EventoId",
                table: "RedesSociais",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSociais_Palestrantes_PalestranteId",
                table: "RedesSociais",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedesSociais_Eventos_EventoId",
                table: "RedesSociais");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSociais_Palestrantes_PalestranteId",
                table: "RedesSociais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedesSociais",
                table: "RedesSociais");

            migrationBuilder.RenameTable(
                name: "RedesSociais",
                newName: "RedesSocials");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSociais_PalestranteId",
                table: "RedesSocials",
                newName: "IX_RedesSocials_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSociais_EventoId",
                table: "RedesSocials",
                newName: "IX_RedesSocials_EventoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedesSocials",
                table: "RedesSocials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSocials_Eventos_EventoId",
                table: "RedesSocials",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSocials_Palestrantes_PalestranteId",
                table: "RedesSocials",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id");
        }
    }
}
