namespace apbd_kolos2.Models.RequestDTOs;

public class ExhibitionRequestDTO
{
    public string Title { get; set; } = string.Empty;
    public string Gallery { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public ICollection<ArtworkRequestDTO> Artworks { get; set; } = [];
}
