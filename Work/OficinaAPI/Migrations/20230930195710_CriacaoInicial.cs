using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscalPeca",
                columns: table => new
                {
                    NotaFiscaPecalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    NumNota = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalPeca", x => x.NotaFiscaPecalId);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscalServico",
                columns: table => new
                {
                    NotaFiscalServicoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    NumNota = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscalServico", x => x.NotaFiscalServicoId);
                });

            migrationBuilder.CreateTable(
                name: "Peca",
                columns: table => new
                {
                    PecaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Fornecedor = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peca", x => x.PecaId);
                });

            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    CarroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Modelo = table.Column<string>(type: "TEXT", nullable: true),
                    Cor = table.Column<string>(type: "TEXT", nullable: true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.CarroId);
                    table.ForeignKey(
                        name: "FK_Carro_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateTable(
                name: "CheckList",
                columns: table => new
                {
                    CheckListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    OrdemServico = table.Column<string>(type: "TEXT", nullable: true),
                    CarroId = table.Column<int>(type: "INTEGER", nullable: true),
                    NotaFiscalServicoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckList", x => x.CheckListId);
                    table.ForeignKey(
                        name: "FK_CheckList_Carro_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carro",
                        principalColumn: "CarroId");
                    table.ForeignKey(
                        name: "FK_CheckList_NotaFiscalServico_NotaFiscalServicoId",
                        column: x => x.NotaFiscalServicoId,
                        principalTable: "NotaFiscalServico",
                        principalColumn: "NotaFiscalServicoId");
                });

            migrationBuilder.CreateTable(
                name: "CheckListPeca",
                columns: table => new
                {
                    CheckListPecaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CheckListId = table.Column<int>(type: "INTEGER", nullable: true),
                    PecaId = table.Column<int>(type: "INTEGER", nullable: true),
                    NotaFiscalPecaId = table.Column<int>(type: "INTEGER", nullable: true),
                    NotaFiscalServicoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListPeca", x => x.CheckListPecaId);
                    table.ForeignKey(
                        name: "FK_CheckListPeca_CheckList_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckList",
                        principalColumn: "CheckListId");
                    table.ForeignKey(
                        name: "FK_CheckListPeca_NotaFiscalPeca_NotaFiscalPecaId",
                        column: x => x.NotaFiscalPecaId,
                        principalTable: "NotaFiscalPeca",
                        principalColumn: "NotaFiscaPecalId");
                    table.ForeignKey(
                        name: "FK_CheckListPeca_NotaFiscalServico_NotaFiscalServicoId",
                        column: x => x.NotaFiscalServicoId,
                        principalTable: "NotaFiscalServico",
                        principalColumn: "NotaFiscalServicoId");
                    table.ForeignKey(
                        name: "FK_CheckListPeca_Peca_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Peca",
                        principalColumn: "PecaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carro_ClienteId",
                table: "Carro",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckList_CarroId",
                table: "CheckList",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckList_NotaFiscalServicoId",
                table: "CheckList",
                column: "NotaFiscalServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListPeca_CheckListId",
                table: "CheckListPeca",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListPeca_NotaFiscalPecaId",
                table: "CheckListPeca",
                column: "NotaFiscalPecaId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListPeca_NotaFiscalServicoId",
                table: "CheckListPeca",
                column: "NotaFiscalServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListPeca_PecaId",
                table: "CheckListPeca",
                column: "PecaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListPeca");

            migrationBuilder.DropTable(
                name: "CheckList");

            migrationBuilder.DropTable(
                name: "NotaFiscalPeca");

            migrationBuilder.DropTable(
                name: "Peca");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "NotaFiscalServico");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
