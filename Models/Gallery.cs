namespace apbd_kolos2.Models;

public class Gallery
{
    public int GalleryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime EstablishedDate { get; set; }

    public ICollection<Exhibition> Exhibitions { get; set; } = [];
}
