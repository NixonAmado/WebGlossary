using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

public class WordConfiguration:IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
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
    }

}