using http.Data;
using http.Helper;
using Microsoft.AspNetCore.Mvc;

namespace http.Endpoint.Admin.DodajRestoran
{
    [Route("Admin-DodajRestoran")]
    public class DodajRestoranEndpoint:MyBaseEndpoint<DodajRestoranRequest, NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public DodajRestoranEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<NoResponse> Akcija([FromBody]DodajRestoranRequest request, CancellationToken cancellationToken)
        {
            var restoran = new Data.Models.Restoran
            {
                ID = request.ID,
                Naziv = request.Naziv,
                Opis = request.Opis,
                RadnoVrijemeOd = request.RadnoVrijemeOd,
                RadnoVrijemeDo = request.RadnoVrijemeDo,
                VlasnikRestoranaID = request.VlasnikRestoranaID,
                isObrisan = false,
                Lokacija=request.Lokacija,
            };

            _applicationDbContext.Add(restoran);
            await _applicationDbContext.SaveChangesAsync();

            return new NoResponse();
        }
    }
}
