using apbd_kolos2.Database.Configuration;
using apbd_kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_kolos2.Database;

public class MuseumDbContext : DbContext
{
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Artist> Artists { get; set; }

    public MuseumDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new GalleryConfiguration());
        builder.ApplyConfiguration(new ExhibitionConfiguration());
        builder.ApplyConfiguration(new ExhibitionArtworkConfiguration());
        builder.ApplyConfiguration(new ArtworkConfiguration());
        builder.ApplyConfiguration(new ArtistConfiguration());

        builder.Entity<Gallery>().HasData([new() { GalleryId = 1, Name = "Modern Art Space", EstablishedDate = new DateTime(2001, 9, 12) }]);

        builder.Entity<Artist>().HasData
        (
            [
                new () { ArtistId = 1, FirstName = "Pablo", LastName = "Picasso", BirthDate = new(1881, 10, 25) },
                new () { ArtistId = 2, FirstName = "Frida", LastName = "Kahlo", BirthDate = new(1907, 7, 6) }
            ]
        );

        builder.Entity<Artwork>().HasData
        (
            [
                new () { Title = "Guernica", ArtistId = 1, ArtworkId = 1, YearCreated = 1937 },
                new () { Title = "The Two Fridas", ArtistId = 2, ArtworkId = 2, YearCreated = 1939 }
            ]
        );

        builder.Entity<Exhibition>().HasData
        (
            [
                new ()
                {
                    Title = "20th Century Giants",
                    StartDate = new(2024, 5, 1),
                    EndDate = new(2024, 9, 1),
                    NumberOfArtworks = 2,
                    GalleryId = 1,
                    ExhibitionId = 1
                }
            ]
        );

        builder.Entity<ExhibitionArtwork>().HasData
        (
            [
                new () { ExhibitionId = 1, ArtworkId = 1, InsuranceValue = 1000000 },
                new () { ExhibitionId = 1, ArtworkId = 2, InsuranceValue = 800000 }
            ]
        );
    }
}
