using apbd_kolos2.Database;
using apbd_kolos2.Models.DTOs;
using apbd_kolos2.Models.RequestDTOs;
using Microsoft.EntityFrameworkCore;

namespace apbd_kolos2.Services;

public class DbService : IDbService
{
    protected readonly MuseumDbContext database;

    public DbService(MuseumDbContext database)
    {
        this.database = database;
    }

    public async Task<GalleryDto> GetGalleryExhibitionsByGalleryId(int galleryId)
    {
        var gallery = await this.database.Galleries.Where(gal => gal.GalleryId == galleryId)
        .Include(gal => gal.Exhibitions)
        .Include(gal => gal.Exhibitions).ThenInclude(exh => exh.ExhibitionArtworks)
        .Include(gal => gal.Exhibitions).ThenInclude(exh => exh.ExhibitionArtworks).ThenInclude(exh => exh.Artwork)
        .Include(gal => gal.Exhibitions).ThenInclude(exh => exh.ExhibitionArtworks).ThenInclude(exh => exh.Artwork).ThenInclude(ar => ar.Artist)
        .SingleOrDefaultAsync();

        if (gallery is null) throw new ArgumentNullException("No gallery with given id was found.");
        else return new GalleryDto(gallery);
    }

    public async Task AddExhibition(ExhibitionRequestDTO exhibitionDto)
    {
        if (exhibitionDto.EndDate is not null && exhibitionDto.EndDate < exhibitionDto.StartDate) throw new ArgumentException(message: "The end date has to be later than the start date.");

        using var transaction = await this.database.Database.BeginTransactionAsync();

        try
        {
            var gallery = await this.database.Galleries.Where(gal => gal.Name == exhibitionDto.Gallery).FirstOrDefaultAsync() ?? throw new ArgumentNullException("No gallery with given id was found.");

            var artworks = exhibitionDto.Artworks.Select(a => (dto: a, artowrk: this.database.Artworks.Where(ar => ar.ArtworkId == a.ArtworkId).SingleAsync().GetAwaiter().GetResult())).ToList();

            await this.database.Exhibitions.AddAsync(new Models.Exhibition() { Title = exhibitionDto.Title, StartDate = exhibitionDto.StartDate, EndDate = exhibitionDto.EndDate, NumberOfArtworks = artworks.Count, GalleryId = gallery.GalleryId });

            foreach (var pair in artworks)
            {
                // await this.database.ExhibitionArtworks.AddAsync();
            }

            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw new Exception("An exception during the transaction has been thrown!", e);
        }
    }
}
