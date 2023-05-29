using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nydus2._0.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CBO = table.Column<string>(type: "TEXT", nullable: false),
                    DescricaoAtividades = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDemissao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: false),
                    RazaoSocial = table.Column<string>(type: "TEXT", nullable: false),
                    NomeFantasia = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColaboradorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CargoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataInicioVigencia = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoCargos_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoCargos_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCargos_CargoId",
                table: "HistoricoCargos",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCargos_ColaboradorId",
                table: "HistoricoCargos",
                column: "ColaboradorId");
           
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAdmissao",
                table: "Colaboradores",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDemissao",
                table: "Colaboradores",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "HistoricoCargos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.AlterColumn<string>(
                name: "DataAdmissao",
                table: "Colaboradores",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<string>(
                name: "DataDemissao",
                table: "Colaboradores",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

        }
    }
}
