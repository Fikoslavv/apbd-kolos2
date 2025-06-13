namespace apbd_kolos2.Models;

public class Artist
{
    public int ArtistId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public ICollection<Artwork> Artworks { get; set; } = [];
}
