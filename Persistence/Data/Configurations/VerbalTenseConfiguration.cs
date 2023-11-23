using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

class VerbaltenseConfiguration:IEntityTypeConfiguration<Verbaltense>
{
    public void Configure(EntityTypeBuilder<Verbaltense> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.ToTable("verbaltense");
        builder.Property(e => e.Description).HasMaxLength(70);
    }

}