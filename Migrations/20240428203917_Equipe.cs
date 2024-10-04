using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPro.Migrations
{
    /// <inheritdoc />
    public partial class Equipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamPro_Tb_Equipes_552344",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PaisSede = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AnoFundacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EstadioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPro_Tb_Equipes_552344", x => x.EquipeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamPro_Tb_Equipes_552344");
        }
    }
}
