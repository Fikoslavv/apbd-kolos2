using apbd_kolos2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kolos2.Database.Configuration;

public class GalleryConfiguration : IEntityTypeConfiguration<Gallery>
{
    public void Configure(EntityTypeBuilder<Gallery> builder)
    {
        builder.ToTable(nameof(Gallery));

        builder.HasKey(gal => gal.GalleryId);

        builder.Property(gal => gal.Name).HasMaxLength(50).IsRequired();

        builder.Property(gal => gal.EstablishedDate).IsRequired();

        builder.HasMany(gal => gal.Exhibitions).WithOne(exh => exh.Gallery).HasForeignKey(exh => exh.GalleryId);
    }
}
