using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoDeEsterelizacao.Migrations
{
    public partial class aa : Migration
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
                    Nome = table.Column<string>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materialcs", x => x.MaterialcsId);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    TipoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.TipoID);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Colaborador", x => x.FuncaoID);
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
                    EquipamentoID = table.Column<int>(nullable: false),
                    Capacidade = table.Column<int>(nullable: false),
                    TipoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.TipoID);
                    table.ForeignKey(
                        name: "FK_Equipamento_Tipo_TipoID",
                        column: x => x.TipoID,
                        principalTable: "Tipo",
                        principalColumn: "TipoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Esterilizar",
                columns: table => new
                {
                    EsterilizarID = table.Column<int>(nullable: false),
                    EquipamentoID = table.Column<int>(nullable: false),
                    MaterialcsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esterilizar", x => new { x.MaterialcsID, x.EquipamentoID });
                    table.ForeignKey(
                        name: "FK_Esterilizar_Equipamento_EquipamentoID",
                        column: x => x.EquipamentoID,
                        principalTable: "Equipamento",
                        principalColumn: "TipoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Esterilizar_Materialcs_MaterialcsID",
                        column: x => x.MaterialcsID,
                        principalTable: "Materialcs",
                        principalColumn: "MaterialcsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Esterilizar_EquipamentoID",
                table: "Esterilizar",
                column: "EquipamentoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Esterilizar");

            migrationBuilder.DropTable(
                name: "Funcao");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Materialcs");

            migrationBuilder.DropTable(
                name: "Tipo");
        }
    }
}
