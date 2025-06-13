namespace apbd_kolos2.Models.DTOs;

public class ArtworkDto
{
    public string Title { get; set; } = string.Empty;
    public int YearCreated { get; set; }
    public double InsuranceValue { get; set; }

    public ArtistDto Artist { get; set; }

    public ArtworkDto(Artwork artwork, double insuranceValue)
    {
        this.Title = artwork.Title;
        this.YearCreated = artwork.YearCreated;
        this.InsuranceValue = insuranceValue;

        this.Artist = new(artwork.Artist);
    }
}
