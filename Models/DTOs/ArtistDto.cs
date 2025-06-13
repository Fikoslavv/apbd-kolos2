namespace apbd_kolos2.Models.DTOs;

public class ArtistDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public ArtistDto(Artist artist)
    {
        this.FirstName = artist.FirstName;
        this.LastName = artist.LastName;
        this.BirthDate = artist.BirthDate;
    }
}
