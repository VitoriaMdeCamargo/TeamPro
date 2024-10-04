using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPro.Migrations
{
    /// <inheritdoc />
    public partial class JogadorTreinador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamPro_Tb_Jogadores_552344",
                columns: table => new
                {
                    JogadorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Posicao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Idade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EquipeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPro_Tb_Jogadores_552344", x => x.JogadorId);
                    table.ForeignKey(
                        name: "FK_TeamPro_Tb_Jogadores_552344_TeamPro_Tb_Equipes_552344_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "TeamPro_Tb_Equipes_552344",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamPro_Tb_Treinadores_552344",
                columns: table => new
                {
                    TreinadorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Idade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EquipeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPro_Tb_Treinadores_552344", x => x.TreinadorId);
                    table.ForeignKey(
                        name: "FK_TeamPro_Tb_Treinadores_552344_TeamPro_Tb_Equipes_552344_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "TeamPro_Tb_Equipes_552344",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JogadorPartida",
                columns: table => new
                {
                    JogadoresJogadorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PartidasPartidaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogadorPartida", x => new { x.JogadoresJogadorId, x.PartidasPartidaId });
                    table.ForeignKey(
                        name: "FK_JogadorPartida_TeamPro_Tb_Jogadores_552344_JogadoresJogadorId",
                        column: x => x.JogadoresJogadorId,
                        principalTable: "TeamPro_Tb_Jogadores_552344",
                        principalColumn: "JogadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogadorPartida_TeamPro_Tb_Partidas_552344_PartidasPartidaId",
                        column: x => x.PartidasPartidaId,
                        principalTable: "TeamPro_Tb_Partidas_552344",
                        principalColumn: "PartidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JogadorPartida_PartidasPartidaId",
                table: "JogadorPartida",
                column: "PartidasPartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPro_Tb_Jogadores_552344_EquipeId",
                table: "TeamPro_Tb_Jogadores_552344",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPro_Tb_Treinadores_552344_EquipeId",
                table: "TeamPro_Tb_Treinadores_552344",
                column: "EquipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogadorPartida");

            migrationBuilder.DropTable(
                name: "TeamPro_Tb_Treinadores_552344");

            migrationBuilder.DropTable(
                name: "TeamPro_Tb_Jogadores_552344");
        }
    }
}
