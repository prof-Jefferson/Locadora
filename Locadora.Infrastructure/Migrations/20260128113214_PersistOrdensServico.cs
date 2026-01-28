using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PersistOrdensServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locacao_extras_locacoes_locacao_id",
                table: "locacao_extras");

            migrationBuilder.DropForeignKey(
                name: "FK_locacoes_clientes_cliente_id",
                table: "locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_locacoes_veiculos_veiculo_id",
                table: "locacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_veiculos",
                table: "veiculos");

            migrationBuilder.DropIndex(
                name: "IX_veiculos_placa",
                table: "veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locacoes",
                table: "locacoes");

            migrationBuilder.DropIndex(
                name: "ix_locacoes_cliente_status",
                table: "locacoes");

            migrationBuilder.DropIndex(
                name: "ix_locacoes_veiculo_status",
                table: "locacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "IX_clientes_documento",
                table: "clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locacao_extras",
                table: "locacao_extras");

            migrationBuilder.RenameTable(
                name: "veiculos",
                newName: "Veiculos");

            migrationBuilder.RenameTable(
                name: "locacoes",
                newName: "Locacoes");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Clientes");

            migrationBuilder.RenameTable(
                name: "locacao_extras",
                newName: "LocacaoExtras");

            migrationBuilder.RenameColumn(
                name: "placa",
                table: "Veiculos",
                newName: "Placa");

            migrationBuilder.RenameColumn(
                name: "modelo",
                table: "Veiculos",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "disponivel",
                table: "Veiculos",
                newName: "Disponivel");

            migrationBuilder.RenameColumn(
                name: "categoria",
                table: "Veiculos",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "ativo",
                table: "Veiculos",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "ano",
                table: "Veiculos",
                newName: "Ano");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Veiculos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "valor_diaria",
                table: "Veiculos",
                newName: "ValorDiaria");

            migrationBuilder.RenameColumn(
                name: "criado_em",
                table: "Veiculos",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Locacoes",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "retirada",
                table: "Locacoes",
                newName: "Retirada");

            migrationBuilder.RenameColumn(
                name: "prevista",
                table: "Locacoes",
                newName: "Prevista");

            migrationBuilder.RenameColumn(
                name: "devolucao",
                table: "Locacoes",
                newName: "Devolucao");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Locacoes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "veiculo_id",
                table: "Locacoes",
                newName: "VeiculoId");

            migrationBuilder.RenameColumn(
                name: "valor_previsto",
                table: "Locacoes",
                newName: "ValorPrevisto");

            migrationBuilder.RenameColumn(
                name: "valor_final",
                table: "Locacoes",
                newName: "ValorFinal");

            migrationBuilder.RenameColumn(
                name: "criado_em",
                table: "Locacoes",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "cliente_id",
                table: "Locacoes",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Clientes",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "responsavel",
                table: "Clientes",
                newName: "Responsavel");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Clientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "documento",
                table: "Clientes",
                newName: "Documento");

            migrationBuilder.RenameColumn(
                name: "cnh",
                table: "Clientes",
                newName: "Cnh");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clientes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "razao_social",
                table: "Clientes",
                newName: "RazaoSocial");

            migrationBuilder.RenameColumn(
                name: "criado_em",
                table: "Clientes",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "LocacaoExtras",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LocacaoExtras",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tipo_extra",
                table: "LocacaoExtras",
                newName: "TipoExtra");

            migrationBuilder.RenameColumn(
                name: "preco_por_dia",
                table: "LocacaoExtras",
                newName: "PrecoPorDia");

            migrationBuilder.RenameColumn(
                name: "locacao_id",
                table: "LocacaoExtras",
                newName: "LocacaoId");

            migrationBuilder.RenameIndex(
                name: "ix_locacao_extras_locacao",
                table: "LocacaoExtras",
                newName: "IX_LocacaoExtras_LocacaoId");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Veiculos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Veiculos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Veiculos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorDiaria",
                table: "Veiculos",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Locacoes",
                type: "varchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPrevisto",
                table: "Locacoes",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorFinal",
                table: "Locacoes",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldMaxLength: 2)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel",
                table: "Clientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cnh",
                table: "Clientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Clientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(160)",
                oldMaxLength: 160,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TipoExtra",
                table: "LocacaoExtras",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoPorDia",
                table: "LocacaoExtras",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocacaoExtras",
                table: "LocacaoExtras",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ordens_servico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VeiculoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tipo = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CriadoEmUtc = table.Column<DateTime>(type: "datetime", nullable: false),
                    ConcluidoEmUtc = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordens_servico", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_ClienteId",
                table: "Locacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_VeiculoId",
                table: "Locacoes",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_ordens_servico_VeiculoId_Status",
                table: "ordens_servico",
                columns: new[] { "VeiculoId", "Status" });

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoExtras_Locacoes_LocacaoId",
                table: "LocacaoExtras",
                column: "LocacaoId",
                principalTable: "Locacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Clientes_ClienteId",
                table: "Locacoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Veiculos_VeiculoId",
                table: "Locacoes",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoExtras_Locacoes_LocacaoId",
                table: "LocacaoExtras");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Clientes_ClienteId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Veiculos_VeiculoId",
                table: "Locacoes");

            migrationBuilder.DropTable(
                name: "ordens_servico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_ClienteId",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_VeiculoId",
                table: "Locacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocacaoExtras",
                table: "LocacaoExtras");

            migrationBuilder.RenameTable(
                name: "Veiculos",
                newName: "veiculos");

            migrationBuilder.RenameTable(
                name: "Locacoes",
                newName: "locacoes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "clientes");

            migrationBuilder.RenameTable(
                name: "LocacaoExtras",
                newName: "locacao_extras");

            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "veiculos",
                newName: "placa");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "veiculos",
                newName: "modelo");

            migrationBuilder.RenameColumn(
                name: "Disponivel",
                table: "veiculos",
                newName: "disponivel");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "veiculos",
                newName: "categoria");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "veiculos",
                newName: "ativo");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "veiculos",
                newName: "ano");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "veiculos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ValorDiaria",
                table: "veiculos",
                newName: "valor_diaria");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "veiculos",
                newName: "criado_em");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "locacoes",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Retirada",
                table: "locacoes",
                newName: "retirada");

            migrationBuilder.RenameColumn(
                name: "Prevista",
                table: "locacoes",
                newName: "prevista");

            migrationBuilder.RenameColumn(
                name: "Devolucao",
                table: "locacoes",
                newName: "devolucao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "locacoes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VeiculoId",
                table: "locacoes",
                newName: "veiculo_id");

            migrationBuilder.RenameColumn(
                name: "ValorPrevisto",
                table: "locacoes",
                newName: "valor_previsto");

            migrationBuilder.RenameColumn(
                name: "ValorFinal",
                table: "locacoes",
                newName: "valor_final");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "locacoes",
                newName: "criado_em");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "locacoes",
                newName: "cliente_id");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "clientes",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "Responsavel",
                table: "clientes",
                newName: "responsavel");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "clientes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "clientes",
                newName: "documento");

            migrationBuilder.RenameColumn(
                name: "Cnh",
                table: "clientes",
                newName: "cnh");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "clientes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RazaoSocial",
                table: "clientes",
                newName: "razao_social");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "clientes",
                newName: "criado_em");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "locacao_extras",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "locacao_extras",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TipoExtra",
                table: "locacao_extras",
                newName: "tipo_extra");

            migrationBuilder.RenameColumn(
                name: "PrecoPorDia",
                table: "locacao_extras",
                newName: "preco_por_dia");

            migrationBuilder.RenameColumn(
                name: "LocacaoId",
                table: "locacao_extras",
                newName: "locacao_id");

            migrationBuilder.RenameIndex(
                name: "IX_LocacaoExtras_LocacaoId",
                table: "locacao_extras",
                newName: "ix_locacao_extras_locacao");

            migrationBuilder.AlterColumn<string>(
                name: "placa",
                table: "veiculos",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "modelo",
                table: "veiculos",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "categoria",
                table: "veiculos",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor_diaria",
                table: "veiculos",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "locacoes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor_previsto",
                table: "locacoes",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor_final",
                table: "locacoes",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "clientes",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "responsavel",
                table: "clientes",
                type: "varchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "clientes",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "documento",
                table: "clientes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "cnh",
                table: "clientes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "razao_social",
                table: "clientes",
                type: "varchar(160)",
                maxLength: 160,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "tipo_extra",
                table: "locacao_extras",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "preco_por_dia",
                table: "locacao_extras",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_veiculos",
                table: "veiculos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locacoes",
                table: "locacoes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locacao_extras",
                table: "locacao_extras",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_veiculos_placa",
                table: "veiculos",
                column: "placa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_locacoes_cliente_status",
                table: "locacoes",
                columns: new[] { "cliente_id", "status" });

            migrationBuilder.CreateIndex(
                name: "ix_locacoes_veiculo_status",
                table: "locacoes",
                columns: new[] { "veiculo_id", "status" });

            migrationBuilder.CreateIndex(
                name: "IX_clientes_documento",
                table: "clientes",
                column: "documento",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_locacao_extras_locacoes_locacao_id",
                table: "locacao_extras",
                column: "locacao_id",
                principalTable: "locacoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locacoes_clientes_cliente_id",
                table: "locacoes",
                column: "cliente_id",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_locacoes_veiculos_veiculo_id",
                table: "locacoes",
                column: "veiculo_id",
                principalTable: "veiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
