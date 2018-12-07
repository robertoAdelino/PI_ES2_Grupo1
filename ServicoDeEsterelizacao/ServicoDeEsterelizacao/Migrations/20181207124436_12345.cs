using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicoDeEsterelizacao.Migrations
{
    public partial class _12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Funcao_FuncaoID",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Tipo_TipoID",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Esterilizar_Equipamento_EquipamentoID",
                table: "Esterilizar");

            migrationBuilder.DropForeignKey(
                name: "FK_Esterilizar_Materialcs_MaterialcsID",
                table: "Esterilizar");

            migrationBuilder.AlterColumn<int>(
                name: "TipoID",
                table: "Equipamento",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "TipoID1",
                table: "Equipamento",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuncaoID",
                table: "Colaborador",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "FuncaoID1",
                table: "Colaborador",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_TipoID1",
                table: "Equipamento",
                column: "TipoID1");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_FuncaoID1",
                table: "Colaborador",
                column: "FuncaoID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Funcao_FuncaoID1",
                table: "Colaborador",
                column: "FuncaoID1",
                principalTable: "Funcao",
                principalColumn: "FuncaoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Tipo_TipoID1",
                table: "Equipamento",
                column: "TipoID1",
                principalTable: "Tipo",
                principalColumn: "TipoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Esterilizar_Equipamento_EquipamentoID",
                table: "Esterilizar",
                column: "EquipamentoID",
                principalTable: "Equipamento",
                principalColumn: "TipoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Esterilizar_Materialcs_MaterialcsID",
                table: "Esterilizar",
                column: "MaterialcsID",
                principalTable: "Materialcs",
                principalColumn: "MaterialcsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Funcao_FuncaoID1",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Tipo_TipoID1",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Esterilizar_Equipamento_EquipamentoID",
                table: "Esterilizar");

            migrationBuilder.DropForeignKey(
                name: "FK_Esterilizar_Materialcs_MaterialcsID",
                table: "Esterilizar");

            migrationBuilder.DropIndex(
                name: "IX_Equipamento_TipoID1",
                table: "Equipamento");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_FuncaoID1",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "TipoID1",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "FuncaoID1",
                table: "Colaborador");

            migrationBuilder.AlterColumn<int>(
                name: "TipoID",
                table: "Equipamento",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "FuncaoID",
                table: "Colaborador",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Funcao_FuncaoID",
                table: "Colaborador",
                column: "FuncaoID",
                principalTable: "Funcao",
                principalColumn: "FuncaoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Tipo_TipoID",
                table: "Equipamento",
                column: "TipoID",
                principalTable: "Tipo",
                principalColumn: "TipoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Esterilizar_Equipamento_EquipamentoID",
                table: "Esterilizar",
                column: "EquipamentoID",
                principalTable: "Equipamento",
                principalColumn: "TipoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Esterilizar_Materialcs_MaterialcsID",
                table: "Esterilizar",
                column: "MaterialcsID",
                principalTable: "Materialcs",
                principalColumn: "MaterialcsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
