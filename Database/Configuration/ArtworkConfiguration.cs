using apbd_kolos2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kolos2.Database.Configuration;

public class ArtworkConfiguration : IEntityTypeConfiguration<Artwork>
{
    public void Configure(EntityTypeBuilder<Artwork> builder)
    {
        builder.ToTable(nameof(Artwork));

        builder.HasKey(ar => ar.ArtworkId);

        builder.Property(ar => ar.Title).HasMaxLength(100).IsRequired();

        builder.Property(ar => ar.YearCreated).IsRequired();

        builder.HasOne(ar => ar.Artist).WithMany(ar => ar.Artworks).HasForeignKey(ar => ar.ArtistId);

        builder.HasMany(ar => ar.ExhibitionArtworks).WithOne(ea => ea.Artwork).HasForeignKey(ea => ea.ArtworkId);
    }
}
