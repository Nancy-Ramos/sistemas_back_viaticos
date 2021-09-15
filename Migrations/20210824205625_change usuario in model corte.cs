using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSystemsATSM.Migrations
{
    public partial class changeusuarioinmodelcorte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corte_Usuario_UsuarioId",
                table: "Corte");

            migrationBuilder.DropIndex(
                name: "IX_Corte_UsuarioId",
                table: "Corte");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Corte");

            migrationBuilder.AddColumn<int>(
                name: "Usuario",
                table: "Corte",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Corte");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Corte",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corte_UsuarioId",
                table: "Corte",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Corte_Usuario_UsuarioId",
                table: "Corte",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
