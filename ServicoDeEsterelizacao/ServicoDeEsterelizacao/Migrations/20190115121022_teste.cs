using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoDeEsterelizacao.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    FuncaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.FuncaoID);
                });

            migrationBuilder.CreateTable(
                name: "Materialcs",
                columns: table => new
                {
                    MaterialcsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materialcs", x => x.MaterialcsId);
                });

            migrationBuilder.CreateTable(
                name: "Posto",
                columns: table => new
                {
                    PostoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posto", x => x.PostoId);
                });

            migrationBuilder.CreateTable(
                name: "Regras",
                columns: table => new
                {
                    RegrasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 10000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regras", x => x.RegrasID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    TipoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.TipoID);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    TurnoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    HoraInicioManha = table.Column<int>(nullable: false),
                    HoraFimManha = table.Column<int>(nullable: false),
                    HoraInicioTarde = table.Column<int>(nullable: false),
                    HoraFimTarde = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.TurnoId);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FuncaoID = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Morada = table.Column<string>(nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    Cc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.ColaboradorId);
                    table.ForeignKey(
                        name: "FK_Colaborador_Funcao_FuncaoID",
                        column: x => x.FuncaoID,
                        principalTable: "Funcao",
                        principalColumn: "FuncaoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capacidade = table.Column<int>(nullable: false),
                    TipoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentoID);
                    table.ForeignKey(
                        name: "FK_Equipamento_Tipo_TipoID",
                        column: x => x.TipoID,
                        principalTable: "Tipo",
                        principalColumn: "TipoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicioManha = table.Column<DateTime>(nullable: false),
                    DataFimManha = table.Column<DateTime>(nullable: false),
                    DataInicioTarde = table.Column<DateTime>(nullable: false),
                    DataFimTarde = table.Column<DateTime>(nullable: false),
                    TurnoId = table.Column<int>(nullable: false),
                    PostoId = table.Column<int>(nullable: false),
                    ColaboradorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioID);
                    table.ForeignKey(
                        name: "FK_Horario_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Horario_Posto_PostoId",
                        column: x => x.PostoId,
                        principalTable: "Posto",
                        principalColumn: "PostoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Horario_Turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turno",
                        principalColumn: "TurnoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trabalho_Posto",
                columns: table => new
                {
                    Trabalho_PostoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipamentoID = table.Column<int>(nullable: false),
                    MaterialcsID = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    HorarioID = table.Column<int>(nullable: false),
                    DataServico = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabalho_Posto", x => x.Trabalho_PostoID);
                    table.ForeignKey(
                        name: "FK_Trabalho_Posto_Equipamento_EquipamentoID",
                        column: x => x.EquipamentoID,
                        principalTable: "Equipamento",
                        principalColumn: "EquipamentoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trabalho_Posto_Horario_HorarioID",
                        column: x => x.HorarioID,
                        principalTable: "Horario",
                        principalColumn: "HorarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trabalho_Posto_Materialcs_MaterialcsID",
                        column: x => x.MaterialcsID,
                        principalTable: "Materialcs",
                        principalColumn: "MaterialcsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_FuncaoID",
                table: "Colaborador",
                column: "FuncaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_TipoID",
                table: "Equipamento",
                column: "TipoID");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_ColaboradorId",
                table: "Horario",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_PostoId",
                table: "Horario",
                column: "PostoId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_TurnoId",
                table: "Horario",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalho_Posto_EquipamentoID",
                table: "Trabalho_Posto",
                column: "EquipamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalho_Posto_HorarioID",
                table: "Trabalho_Posto",
                column: "HorarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalho_Posto_MaterialcsID",
                table: "Trabalho_Posto",
                column: "MaterialcsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regras");

            migrationBuilder.DropTable(
                name: "Trabalho_Posto");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Materialcs");

            migrationBuilder.DropTable(
                name: "Tipo");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Posto");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "Funcao");
        }
    }
}
