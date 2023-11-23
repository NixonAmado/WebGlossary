

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class PhaseConfiguration:IEntityTypeConfiguration<Phase>
{
    public void Configure(EntityTypeBuilder<Phase> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("phase");

        builder.HasIndex(e => e.PhaseTypeId, "PhaseType_id_idx");

        builder.HasIndex(e => e.PhaseStructureId, "phaseStructure_id_idx");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Phase1)
            .HasMaxLength(255)
            .HasColumnName("Phase");
        builder.Property(e => e.PhaseStructureId).HasColumnName("PhaseStructure_id");
        builder.Property(e => e.PhaseTypeId).HasColumnName("PhaseType_id");
        builder.Property(e => e.PhaseVerbalTenseId).HasColumnName("PhaseVerbalTense_id");
        builder.Property(e => e.Translation).HasMaxLength(255);

        builder.HasOne(d => d.PhaseStructure).WithMany(p => p.Phases)
            .HasForeignKey(d => d.PhaseStructureId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("PhaseStructure_id");

        builder.HasOne(d => d.PhaseStructureNavigation).WithMany(p => p.Phases)
            .HasForeignKey(d => d.PhaseStructureId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("PhaseVerbalTense_id");

        builder.HasOne(d => d.PhaseType).WithMany(p => p.Phases)
            .HasForeignKey(d => d.PhaseTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("PhaseType_id");
}
}  
  
 