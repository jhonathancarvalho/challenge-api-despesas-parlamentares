using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DespesasParlamentares.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deputados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnidadeFederativa = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PartidoPolitico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DataAtualizacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DataExclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deputados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeputadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataEmissao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Fornecedor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrlNotaFiscal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DataAtualizacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DataExclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesas_Deputados_DeputadoId",
                        column: x => x.DeputadoId,
                        principalTable: "Deputados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_DeputadoId",
                table: "Despesas",
                column: "DeputadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Deputados");
        }
    }
}
