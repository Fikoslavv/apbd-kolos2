namespace apbd_kolos2.Models.DTOs;

public class GalleryDto
{
    public int GalleryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime EstablishedDate { get; set; }

    public ICollection<ArtworkDto> Exhibitions { get; set; }

    public GalleryDto(Gallery gallery)
    {
        this.GalleryId = gallery.GalleryId;
        this.Name = gallery.Name;
        this.EstablishedDate = gallery.EstablishedDate;

        this.Exhibitions = gallery.Exhibitions.SelectMany(e => e.ExhibitionArtworks).Select(ea => new ArtworkDto(ea.Artwork, ea.InsuranceValue)).ToList();
    }
}
