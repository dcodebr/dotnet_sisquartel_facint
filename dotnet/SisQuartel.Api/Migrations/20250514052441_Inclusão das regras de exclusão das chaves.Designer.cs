﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SisQuartel.Api.Repositories;

#nullable disable

namespace SisQuartel.Api.Migrations
{
    [DbContext(typeof(SisQuartelContext))]
    [Migration("20250514052441_Inclusão das regras de exclusão das chaves")]
    partial class Inclusãodasregrasdeexclusãodaschaves
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SisQuartel.Api.Models.Batalhao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Identificacao")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("identificacao");

                    b.HasKey("Id");

                    b.ToTable("Batalhoes");
                });

            modelBuilder.Entity("SisQuartel.Api.Models.Militar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BatalhaoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<int?>("PatenteId")
                        .HasColumnType("int")
                        .HasColumnName("id_patente");

                    b.HasKey("Id");

                    b.HasIndex("BatalhaoId");

                    b.HasIndex("PatenteId");

                    b.ToTable("militar", (string)null);
                });

            modelBuilder.Entity("SisQuartel.Api.Models.Patente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Graduacao")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("graduacao");

                    b.HasKey("Id");

                    b.ToTable("Patentes");
                });

            modelBuilder.Entity("SisQuartel.Api.Models.Militar", b =>
                {
                    b.HasOne("SisQuartel.Api.Models.Batalhao", "Batalhao")
                        .WithMany("Militares")
                        .HasForeignKey("BatalhaoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SisQuartel.Api.Models.Patente", "Patente")
                        .WithMany("Militares")
                        .HasForeignKey("PatenteId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Batalhao");

                    b.Navigation("Patente");
                });

            modelBuilder.Entity("SisQuartel.Api.Models.Batalhao", b =>
                {
                    b.Navigation("Militares");
                });

            modelBuilder.Entity("SisQuartel.Api.Models.Patente", b =>
                {
                    b.Navigation("Militares");
                });
#pragma warning restore 612, 618
        }
    }
}
