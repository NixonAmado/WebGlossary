using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data;

public class WordTypeConfiguration:IEntityTypeConfiguration<Wordtype>
{
    public void Configure(EntityTypeBuilder<Wordtype> builder)
    {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("wordtype");

            builder.Property(e => e.Description).HasMaxLength(70);
    }

    public class WordType
    {
    }
}