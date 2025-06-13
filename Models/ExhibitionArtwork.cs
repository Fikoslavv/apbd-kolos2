namespace apbd_kolos2.Models;

public class ExhibitionArtwork
{
    public int ExhibitionId { get; set; }
    public int ArtworkId { get; set; }
    public double InsuranceValue { get; set; }

    public Artwork Artwork { get; set; } = null!;
    public Exhibition Exhibition { get; set; } = null!;
}
