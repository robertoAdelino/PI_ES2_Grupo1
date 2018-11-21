using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoDeEsterelizacao.Migrations.EquipamentoDb
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materialcs",
                columns: table => new
                {
                    MaterialcsId = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materialcs", x => x.MaterialcsId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoID = table.Column<string>(maxLength: 2, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Quantidade = table.Column<int>(maxLength: 1000, nullable: false),
                    MaterialcsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentoID);
                    table.ForeignKey(
                        name: "FK_Equipamento_Materialcs_MaterialcsId",
                        column: x => x.MaterialcsId,
                        principalTable: "Materialcs",
                        principalColumn: "MaterialcsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_MaterialcsId",
                table: "Equipamento",
                column: "MaterialcsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Materialcs");
        }
    }
}
