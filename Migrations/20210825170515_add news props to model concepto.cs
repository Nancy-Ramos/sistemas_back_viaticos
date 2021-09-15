using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSystemsATSM.Migrations
{
    public partial class addnewspropstomodelconcepto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Corte",
                table: "Concepto");

            migrationBuilder.AddColumn<string>(
                name: "Factura",
                table: "Concepto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Concepto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Folio",
                table: "Concepto",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Factura",
                table: "Concepto");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Concepto");

            migrationBuilder.DropColumn(
                name: "Folio",
                table: "Concepto");

            migrationBuilder.AddColumn<int>(
                name: "Corte",
                table: "Concepto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
