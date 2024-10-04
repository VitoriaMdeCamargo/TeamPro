using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPro.Migrations
{
    /// <inheritdoc />
    public partial class EstadioPartida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamPro_Tb_Estadios_552344",
                columns: table => new
                {
                    EstadioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Capacidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AnoConstrucao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EquipeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPro_Tb_Estadios_552344", x => x.EstadioId);
                    table.ForeignKey(
                        name: "FK_TeamPro_Tb_Estadios_552344_TeamPro_Tb_Equipes_552344_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "TeamPro_Tb_Equipes_552344",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamPro_Tb_Partidas_552344",
                columns: table => new
                {
                    PartidaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Estadio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EquipeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPro_Tb_Partidas_552344", x => x.PartidaId);
                    table.ForeignKey(
                        name: "FK_TeamPro_Tb_Partidas_552344_TeamPro_Tb_Equipes_552344_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "TeamPro_Tb_Equipes_552344",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamPro_Tb_Estadios_552344_EquipeId",
                table: "TeamPro_Tb_Estadios_552344",
                column: "EquipeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamPro_Tb_Partidas_552344_EquipeId",
                table: "TeamPro_Tb_Partidas_552344",
                column: "EquipeId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamPro_Tb_Estadios_552344");

            migrationBuilder.DropTable(
                name: "TeamPro_Tb_Partidas_552344");
        }
    }
}
