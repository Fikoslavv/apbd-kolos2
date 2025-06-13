using apbd_kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_kolos2.Controllers;

[ApiController]
[Route("galleries")]
public class GalleryController : ControllerBase
{
    protected IDbService service;

    public GalleryController(IDbService service) { this.service = service; }

    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> GetGalleryExhibitionsByGalleryId(int id)
    {
        try
        {
            return this.Ok(await this.service.GetGalleryExhibitionsByGalleryId(id));
        }
        catch (ArgumentNullException e) { return this.NotFound(e.Message); }
        catch (Exception e) { return this.StatusCode(500, e.Message); }
    }
}
