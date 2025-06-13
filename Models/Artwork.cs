namespace apbd_kolos2.Models;

public class Artwork
{
    public int ArtworkId { get; set; }
    public int ArtistId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int YearCreated { get; set; }

    public Artist Artist { get; set; } = null!;
    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = [];
}
