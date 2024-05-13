using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACME.API.Migrations
{
    public partial class ACME : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "varchar(60)", nullable: false),
                    EmailCliente = table.Column<string>(type: "varchar(60)", nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Pago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "varchar(20)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "DataCriacao", "EmailCliente", "NomeCliente", "Pago" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "Maria@gmail.com", "Maria", true },
                    { 2, new DateTimeOffset(new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "Josegmail.com", "Jose", true }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "NomeProduto", "Valor" },
                values: new object[,]
                {
                    { 1, "Martelo", 10m },
                    { 2, "Serrote", 20m },
                    { 3, "Prego", 3m }
                });

            migrationBuilder.InsertData(
                table: "ItensPedidos",
                columns: new[] { "Id", "IdPedido", "IdProduto", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, 1, 5 },
                    { 2, 1, 2, 7 },
                    { 3, 2, 2, 2 },
                    { 4, 2, 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_IdPedido",
                table: "ItensPedidos",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_IdProduto",
                table: "ItensPedidos",
                column: "IdProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
