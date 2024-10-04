﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using TeamPro.Persistence;

#nullable disable

namespace TeamPro.Migrations
{
    [DbContext(typeof(TeamProDbContext))]
    [Migration("20240428205235_JogadorTreinador")]
    partial class JogadorTreinador
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JogadorPartida", b =>
                {
                    b.Property<int>("JogadoresJogadorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PartidasPartidaId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("JogadoresJogadorId", "PartidasPartidaId");

                    b.HasIndex("PartidasPartidaId");

                    b.ToTable("JogadorPartida");
                });

            modelBuilder.Entity("TeamPro.Models.Equipe", b =>
                {
                    b.Property<int>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipeId"));

                    b.Property<int>("AnoFundacao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("EstadioId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PaisSede")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("EquipeId");

                    b.ToTable("TeamPro_Tb_Equipes_552344");
                });

            modelBuilder.Entity("TeamPro.Models.Estadio", b =>
                {
                    b.Property<int>("EstadioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadioId"));

                    b.Property<int>("AnoConstrucao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Capacidade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("EquipeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("EstadioId");

                    b.HasIndex("EquipeId")
                        .IsUnique();

                    b.ToTable("TeamPro_Tb_Estadios_552344");
                });

            modelBuilder.Entity("TeamPro.Models.Jogador", b =>
                {
                    b.Property<int>("JogadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JogadorId"));

                    b.Property<int>("EquipeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Idade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Posicao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("Salario")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal");

                    b.HasKey("JogadorId");

                    b.HasIndex("EquipeId");

                    b.ToTable("TeamPro_Tb_Jogadores_552344");
                });

            modelBuilder.Entity("TeamPro.Models.Partida", b =>
                {
                    b.Property<int>("PartidaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartidaId"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("EquipeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Estadio")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PartidaId");

                    b.HasIndex("EquipeId");

                    b.ToTable("TeamPro_Tb_Partidas_552344");
                });

            modelBuilder.Entity("TeamPro.Models.Treinador", b =>
                {
                    b.Property<int>("TreinadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TreinadorId"));

                    b.Property<int>("EquipeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Idade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("Salario")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal");

                    b.HasKey("TreinadorId");

                    b.HasIndex("EquipeId");

                    b.ToTable("TeamPro_Tb_Treinadores_552344");
                });

            modelBuilder.Entity("JogadorPartida", b =>
                {
                    b.HasOne("TeamPro.Models.Jogador", null)
                        .WithMany()
                        .HasForeignKey("JogadoresJogadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamPro.Models.Partida", null)
                        .WithMany()
                        .HasForeignKey("PartidasPartidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamPro.Models.Estadio", b =>
                {
                    b.HasOne("TeamPro.Models.Equipe", "Equipe")
                        .WithOne("Estadio")
                        .HasForeignKey("TeamPro.Models.Estadio", "EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("TeamPro.Models.Jogador", b =>
                {
                    b.HasOne("TeamPro.Models.Equipe", "Equipe")
                        .WithMany("Jogadores")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("TeamPro.Models.Partida", b =>
                {
                    b.HasOne("TeamPro.Models.Equipe", "Equipe")
                        .WithMany()
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("TeamPro.Models.Treinador", b =>
                {
                    b.HasOne("TeamPro.Models.Equipe", "Equipe")
                        .WithMany()
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("TeamPro.Models.Equipe", b =>
                {
                    b.Navigation("Estadio");

                    b.Navigation("Jogadores");
                });
#pragma warning restore 612, 618
        }
    }
}
