
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class PhaseverbaltenseConfiguration:IEntityTypeConfiguration<Phaseverbaltense>
{
    public void Configure(EntityTypeBuilder<Phaseverbaltense> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("Phaseverbaltense");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Description).HasMaxLength(255);
    }
}  
  
 