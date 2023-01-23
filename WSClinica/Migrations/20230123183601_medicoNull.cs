using Microsoft.EntityFrameworkCore.Migrations;

namespace WSClinica.Migrations
{
    public partial class medicoNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente");

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "Paciente",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente");

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "Paciente",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Medico_MedicoId",
                table: "Paciente",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
