using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

public class PhasestructureConfiguration:IEntityTypeConfiguration<Phasestructure>
{
    public void Configure(EntityTypeBuilder<Phasestructure> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("phasestructure");

        builder.Property(e => e.Description).HasMaxLength(70);
    }
}  
  
 