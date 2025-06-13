namespace apbd_kolos2.Models;

public class Exhibition
{
    public int ExhibitionId { get; set; }
    public int GalleryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int NumberOfArtworks { get; set; }

    public Gallery Gallery { get; set; } = null!;
    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = [];
}
