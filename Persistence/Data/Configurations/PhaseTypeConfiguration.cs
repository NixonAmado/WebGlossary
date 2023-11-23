
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class PhasetypeConfiguration:IEntityTypeConfiguration<Phasetype>
{
    public void Configure(EntityTypeBuilder<Phasetype> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("phasetype");

        builder.Property(e => e.Description).HasMaxLength(70);
    }
}  
  
 