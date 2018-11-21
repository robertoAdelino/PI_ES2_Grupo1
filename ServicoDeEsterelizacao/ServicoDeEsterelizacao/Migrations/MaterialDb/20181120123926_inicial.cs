using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoDeEsterelizacao.Migrations.MaterialDb
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaterialcsId",
                table: "Materialcs",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoID = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    CapacidadeMax = table.Column<int>(nullable: false),
                    CapacidadeMin = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    MaterialcsId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.MaterialcsId);
                    table.ForeignKey(
                        name: "FK_Equipamento_Materialcs_MaterialcsId",
                        column: x => x.MaterialcsId,
                        principalTable: "Materialcs",
                        principalColumn: "MaterialcsId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialcsId",
                table: "Materialcs",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
