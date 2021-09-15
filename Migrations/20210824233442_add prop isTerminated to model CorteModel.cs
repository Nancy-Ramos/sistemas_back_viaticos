using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSystemsATSM.Migrations
{
    public partial class addpropisTerminatedtomodelCorteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concepto_Corte_CorteModelId",
                table: "Concepto");

            migrationBuilder.DropIndex(
                name: "IX_Concepto_CorteModelId",
                table: "Concepto");

            migrationBuilder.DropColumn(
                name: "CorteModelId",
                table: "Concepto");

            migrationBuilder.AddColumn<bool>(
                name: "IsTerminated",
                table: "Corte",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTerminated",
                table: "Corte");

            migrationBuilder.AddColumn<int>(
                name: "CorteModelId",
                table: "Concepto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concepto_CorteModelId",
                table: "Concepto",
                column: "CorteModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concepto_Corte_CorteModelId",
                table: "Concepto",
                column: "CorteModelId",
                principalTable: "Corte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
