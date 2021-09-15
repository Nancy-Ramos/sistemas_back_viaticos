using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSystemsATSM.Migrations
{
    public partial class changepropertycorteinmodelconcepto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concepto_Corte_CorteId",
                table: "Concepto");

            migrationBuilder.RenameColumn(
                name: "CorteId",
                table: "Concepto",
                newName: "CorteModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Concepto_CorteId",
                table: "Concepto",
                newName: "IX_Concepto_CorteModelId");

            migrationBuilder.AddColumn<int>(
                name: "Corte",
                table: "Concepto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Concepto_Corte_CorteModelId",
                table: "Concepto",
                column: "CorteModelId",
                principalTable: "Corte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concepto_Corte_CorteModelId",
                table: "Concepto");

            migrationBuilder.DropColumn(
                name: "Corte",
                table: "Concepto");

            migrationBuilder.RenameColumn(
                name: "CorteModelId",
                table: "Concepto",
                newName: "CorteId");

            migrationBuilder.RenameIndex(
                name: "IX_Concepto_CorteModelId",
                table: "Concepto",
                newName: "IX_Concepto_CorteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concepto_Corte_CorteId",
                table: "Concepto",
                column: "CorteId",
                principalTable: "Corte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
