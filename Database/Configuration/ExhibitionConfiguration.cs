using apbd_kolos2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kolos2.Database.Configuration;

public class ExhibitionConfiguration : IEntityTypeConfiguration<Exhibition>
{
    public void Configure(EntityTypeBuilder<Exhibition> builder)
    {
        builder.ToTable(nameof(Exhibition));

        builder.HasKey(exh => exh.ExhibitionId);

        builder.Property(exh => exh.Title).HasMaxLength(100).IsRequired();

        builder.Property(exh => exh.StartDate).IsRequired();

        builder.Property(exh => exh.EndDate);

        builder.Property(exh => exh.NumberOfArtworks).IsRequired();

        builder.HasOne(exh => exh.Gallery).WithMany(gal => gal.Exhibitions).HasForeignKey(exh => exh.GalleryId);

        builder.HasMany(exh => exh.ExhibitionArtworks).WithOne(ea => ea.Exhibition).HasForeignKey(ea => ea.ExhibitionId);
    }
}
