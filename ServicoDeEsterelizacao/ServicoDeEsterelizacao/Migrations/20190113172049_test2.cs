using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoDeEsterelizacao.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horafim",
                table: "Turno");

            migrationBuilder.DropColumn(
                name: "Horainicio",
                table: "Turno");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Horario",
                newName: "DataInicioTarde");

            migrationBuilder.AddColumn<int>(
                name: "HoraFimManha",
                table: "Turno",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoraFimTarde",
                table: "Turno",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoraInicioManha",
                table: "Turno",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoraInicioTarde",
                table: "Turno",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFimManha",
                table: "Horario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFimTarde",
                table: "Horario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicioManha",
                table: "Horario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFimManha",
                table: "Turno");

            migrationBuilder.DropColumn(
                name: "HoraFimTarde",
                table: "Turno");

            migrationBuilder.DropColumn(
                name: "HoraInicioManha",
                table: "Turno");

            migrationBuilder.DropColumn(
                name: "HoraInicioTarde",
                table: "Turno");

            migrationBuilder.DropColumn(
                name: "DataFimManha",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "DataFimTarde",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "DataInicioManha",
                table: "Horario");

            migrationBuilder.RenameColumn(
                name: "DataInicioTarde",
                table: "Horario",
                newName: "Data");

            migrationBuilder.AddColumn<DateTime>(
                name: "Horafim",
                table: "Turno",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Horainicio",
                table: "Turno",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
