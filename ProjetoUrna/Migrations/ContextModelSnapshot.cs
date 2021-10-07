﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoUrna;

namespace ProjetoUrna.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("ProjetoUrna.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_registro");

                    b.Property<int>("Legenda")
                        .HasColumnType("int")
                        .HasColumnName("legenda");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome_completo");

                    b.Property<string>("NomeVice")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome_vice");

                    b.HasKey("Id");

                    b.ToTable("candidate");
                });

            modelBuilder.Entity("ProjetoUrna.Models.Voting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("CandidateId")
                        .HasColumnType("int")
                        .HasColumnName("candidate_id");

                    b.Property<DateTime>("DataVoto")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_voto");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("voting");
                });

            modelBuilder.Entity("ProjetoUrna.Models.Voting", b =>
                {
                    b.HasOne("ProjetoUrna.Models.Candidate", "Candidate")
                        .WithMany("ListaVotos")
                        .HasForeignKey("CandidateId");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("ProjetoUrna.Models.Candidate", b =>
                {
                    b.Navigation("ListaVotos");
                });
#pragma warning restore 612, 618
        }
    }
}
