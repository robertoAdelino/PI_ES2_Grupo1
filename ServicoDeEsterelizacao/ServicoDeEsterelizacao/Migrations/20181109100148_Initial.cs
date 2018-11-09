using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoDeEsterelizacao.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssistenteOperacional",
                columns: table => new
                {
                    AssistenteOperacionalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistenteOperacional", x => x.AssistenteOperacionalID);
                });

            migrationBuilder.CreateTable(
                name: "DiretorServico",
                columns: table => new
                {
                    DiretorServicoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretorServico", x => x.DiretorServicoID);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeiros",
                columns: table => new
                {
                    EnfermeirosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiros", x => x.EnfermeirosID);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioID);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(nullable: false),
                    Dest = table.Column<int>(nullable: false),
                    funcao = table.Column<string>(nullable: true),
                    EnfermeiroID = table.Column<int>(nullable: false),
                    AssisOperID = table.Column<int>(nullable: false),
                    DirID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => new { x.AssisOperID, x.DirID, x.EnfermeiroID });
                    table.ForeignKey(
                        name: "FK_Colaborador_AssistenteOperacional_AssisOperID",
                        column: x => x.AssisOperID,
                        principalTable: "AssistenteOperacional",
                        principalColumn: "AssistenteOperacionalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaborador_DiretorServico_DirID",
                        column: x => x.DirID,
                        principalTable: "DiretorServico",
                        principalColumn: "DiretorServicoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaborador_Enfermeiros_EnfermeiroID",
                        column: x => x.EnfermeiroID,
                        principalTable: "Enfermeiros",
                        principalColumn: "EnfermeirosID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    ServicoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(nullable: false),
                    ColaboradorAssisOperID = table.Column<int>(nullable: true),
                    ColaboradorDirID = table.Column<int>(nullable: true),
                    ColaboradorEnfermeiroID = table.Column<int>(nullable: true),
                    ColaboradorID = table.Column<int>(nullable: false),
                    HorarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.ServicoID);
                    table.ForeignKey(
                        name: "FK_Servico_Horario_HorarioID",
                        column: x => x.HorarioID,
                        principalTable: "Horario",
                        principalColumn: "HorarioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servico_Colaborador_ColaboradorAssisOperID_ColaboradorDirID_ColaboradorEnfermeiroID",
                        columns: x => new { x.ColaboradorAssisOperID, x.ColaboradorDirID, x.ColaboradorEnfermeiroID },
                        principalTable: "Colaborador",
                        principalColumns: new[] { "AssisOperID", "DirID", "EnfermeiroID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_DirID",
                table: "Colaborador",
                column: "DirID");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_EnfermeiroID",
                table: "Colaborador",
                column: "EnfermeiroID");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_HorarioID",
                table: "Servico",
                column: "HorarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_ColaboradorAssisOperID_ColaboradorDirID_ColaboradorEnfermeiroID",
                table: "Servico",
                columns: new[] { "ColaboradorAssisOperID", "ColaboradorDirID", "ColaboradorEnfermeiroID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "AssistenteOperacional");

            migrationBuilder.DropTable(
                name: "DiretorServico");

            migrationBuilder.DropTable(
                name: "Enfermeiros");
        }
    }
}
