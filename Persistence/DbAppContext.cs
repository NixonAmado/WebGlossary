using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Data;

public partial class DbAppContext : DbContext
{
    public DbAppContext()
    {
    }

    public DbAppContext(DbContextOptions<DbAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Phase> Phases { get; set; }

    public virtual DbSet<Phasestructure> Phasestructures { get; set; }

    public virtual DbSet<Phasetype> Phasetypes { get; set; }

    public virtual DbSet<Phaseverbaltense> Phaseverbaltenses { get; set; }

    public virtual DbSet<Verbaltense> Verbaltenses { get; set; }

    public virtual DbSet<Word> Words { get; set; }

    public virtual DbSet<Wordtype> Wordtypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=123456;database=mydb", Microsoft.builderFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");



        modelBuilder.builder<Verbaltense>(builder =>
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("verbaltense");

            builder.Property(e => e.Description).HasMaxLength(70);
        });

        modelBuilder.builder<Word>(builder =>
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("word");

            builder.HasIndex(e => e.VerbalTenseId, "VerbalTense_id_idx");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Translation).HasMaxLength(50);
            builder.Property(e => e.VerbalTenseId).HasColumnName("VerbalTense_id");
            builder.Property(e => e.WordText)
                .HasMaxLength(70)
                .HasColumnName("wordText");
            builder.Property(e => e.WordTypeId).HasColumnName("WordType_id");

            builder.HasOne(d => d.VerbalTense).WithMany(p => p.Words)
                .HasForeignKey(d => d.VerbalTenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VerbalTense_id");

            builder.HasOne(d => d.VerbalTenseNavigation).WithMany(p => p.Words)
                .HasForeignKey(d => d.VerbalTenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("WordType_id");
        });

        modelBuilder.builder<Wordtype>(builder =>
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("wordtype");

            builder.Property(e => e.Description).HasMaxLength(70);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
