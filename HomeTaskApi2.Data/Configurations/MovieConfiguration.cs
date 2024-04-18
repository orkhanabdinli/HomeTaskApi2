using HomeTaskApi2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeTaskApi2.Data.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(50);
        builder.Property(x => x.Desc)
               .IsRequired()
               .HasMaxLength(300);
        builder.Property(x => x.CostPrice)
               .IsRequired()
               .HasColumnType("decimal(18, 2)");
        builder.Property(x => x.Price)
               .IsRequired()
               .HasColumnType("decimal(18, 2)");
        
        builder.HasOne(x => x.Genre)
               .WithMany(x => x.Movies)
               .HasForeignKey(x => x.GenreId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
