using http.Helper;
using Microsoft.AspNetCore.Mvc;

namespace http.Endpoint.Restoran.GetSlika
{
    [ApiController]
    [Route("Restoran")]
    public class GetSlikaEndpoing:ControllerBase
    {
        [HttpGet("SlikaByID")]
        public async Task<FileContentResult> GetByID(int id, CancellationToken cancellationToken)
        {
            var folderPath = "slike-restorana";

            byte[] slika;
            try
            {
                var fileName = $"{folderPath}/{id}-velika.jpg";
                slika = await System.IO.File.ReadAllBytesAsync(fileName, cancellationToken);
                return File(slika, MimeType.GetMimeType(fileName));
            }
            catch (Exception ex)
            {
                var fileName = $"wwwroot/restoran_images/restoran_img.jpg";
                slika = await System.IO.File.ReadAllBytesAsync(fileName, cancellationToken);
                return File(slika, MimeType.GetMimeType(fileName));
            }

        }
    }
}
