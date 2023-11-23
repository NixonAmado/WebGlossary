﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(DbAppContext))]
    [Migration("20231123035942_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb3_general_ci")
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb3");

            modelBuilder.Entity("Domain.Entities.Phase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Phase1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PhaseStructureId")
                        .HasColumnType("int");

                    b.Property<int>("PhaseTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PhaseVerbalTenseId")
                        .HasColumnType("int");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PhaseStructureId");

                    b.HasIndex("PhaseTypeId");

                    b.HasIndex("PhaseVerbalTenseId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("Domain.Entities.Phasestructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Phasestructures");
                });

            modelBuilder.Entity("Domain.Entities.Phasetype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Phasetypes");
                });

            modelBuilder.Entity("Domain.Entities.Phaseverbaltense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Phaseverbaltenses");
                });

            modelBuilder.Entity("Domain.Entities.Verbaltense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Verbaltenses");
                });

            modelBuilder.Entity("Domain.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<sbyte>("Plural")
                        .HasColumnType("tinyint");

                    b.Property<string>("Translation")
                        .HasColumnType("longtext");

                    b.Property<int>("VerbalTenseId")
                        .HasColumnType("int");

                    b.Property<string>("WordText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("WordTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VerbalTenseId");

                    b.HasIndex("WordTypeId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Domain.Entities.Wordtype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Wordtypes");
                });

            modelBuilder.Entity("Domain.Entities.Phase", b =>
                {
                    b.HasOne("Domain.Entities.Phasestructure", "PhaseStructure")
                        .WithMany("Phases")
                        .HasForeignKey("PhaseStructureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Phasetype", "PhaseType")
                        .WithMany("Phases")
                        .HasForeignKey("PhaseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Phaseverbaltense", "PhaseStructureNavigation")
                        .WithMany("Phases")
                        .HasForeignKey("PhaseVerbalTenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhaseStructure");

                    b.Navigation("PhaseStructureNavigation");

                    b.Navigation("PhaseType");
                });

            modelBuilder.Entity("Domain.Entities.Word", b =>
                {
                    b.HasOne("Domain.Entities.Verbaltense", "VerbalTense")
                        .WithMany("Words")
                        .HasForeignKey("VerbalTenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Wordtype", "VerbalTenseNavigation")
                        .WithMany("Words")
                        .HasForeignKey("WordTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VerbalTense");

                    b.Navigation("VerbalTenseNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Phasestructure", b =>
                {
                    b.Navigation("Phases");
                });

            modelBuilder.Entity("Domain.Entities.Phasetype", b =>
                {
                    b.Navigation("Phases");
                });

            modelBuilder.Entity("Domain.Entities.Phaseverbaltense", b =>
                {
                    b.Navigation("Phases");
                });

            modelBuilder.Entity("Domain.Entities.Verbaltense", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("Domain.Entities.Wordtype", b =>
                {
                    b.Navigation("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
