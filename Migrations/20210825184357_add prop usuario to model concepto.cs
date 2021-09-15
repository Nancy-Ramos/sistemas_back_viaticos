using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSystemsATSM.Migrations
{
    public partial class addpropusuariotomodelconcepto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Usuario",
                table: "Concepto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Concepto");
        }
    }
}
