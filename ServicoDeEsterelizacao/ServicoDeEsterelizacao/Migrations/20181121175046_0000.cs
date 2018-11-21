using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoDeEsterelizacao.Migrations
{
    public partial class _0000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascFilho",
                table: "Colaborador",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Filhos",
                table: "Colaborador",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascFilho",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Filhos",
                table: "Colaborador");
        }
    }
}
