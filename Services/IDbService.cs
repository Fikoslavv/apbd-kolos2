using apbd_kolos2.Models.DTOs;
using apbd_kolos2.Models.RequestDTOs;

namespace apbd_kolos2.Services;

public interface IDbService
{
    public Task<GalleryDto> GetGalleryExhibitionsByGalleryId(int galleryId);
    public Task AddExhibition(ExhibitionRequestDTO exhibitionDto);
}