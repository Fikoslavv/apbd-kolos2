using apbd_kolos2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kolos2.Database.Configuration;

public class ExhibitionArtworkConfiguration : IEntityTypeConfiguration<ExhibitionArtwork>
{
    public void Configure(EntityTypeBuilder<ExhibitionArtwork> builder)
    {
        builder.ToTable(nameof(ExhibitionArtwork));

        builder.HasKey(ea => new { ea.ExhibitionId, ea.ArtworkId });

        builder.Property(ea => ea.InsuranceValue).HasPrecision(10, 2).IsRequired();

        builder.HasOne(ea => ea.Artwork).WithMany(ar => ar.ExhibitionArtworks).HasForeignKey(ea => ea.ArtworkId);

        builder.HasOne(ea => ea.Exhibition).WithMany(exh => exh.ExhibitionArtworks).HasForeignKey(ea => ea.ExhibitionId);
    }
}
