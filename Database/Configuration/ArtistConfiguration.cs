using apbd_kolos2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kolos2.Database.Configuration;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable(nameof(Artist));

        builder.HasKey(ar => ar.ArtistId);

        builder.Property(ar => ar.FirstName).HasMaxLength(100).IsRequired();

        builder.Property(ar => ar.LastName).HasMaxLength(100).IsRequired();

        builder.Property(ar => ar.BirthDate).IsRequired();

        builder.HasMany(ar => ar.Artworks).WithOne(ar => ar.Artist).HasForeignKey(ar => ar.ArtistId);
    }
}
