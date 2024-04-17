using HomeTaskApi2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeTaskApi2.Data.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(45);
    }
}
