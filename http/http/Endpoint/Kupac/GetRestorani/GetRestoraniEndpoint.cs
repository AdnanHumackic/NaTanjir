using http.Data;
using http.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace http.Endpoint.Kupac.GetRestorani
{
    [Route("Kupac-GetRestorani")]
    public class GetRestoraniEndpoint:MyBaseEndpoint<NoRequest, GetRestoraniResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GetRestoraniEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<GetRestoraniResponse> Akcija([FromQuery]NoRequest request, CancellationToken cancellationToken)
        {
            var restoran = await _applicationDbContext
                .Restoran.Where(x=>x.isObrisan==false)
                .Select(x => new GetRestoraniResponseRestorani
                {
                    ID=x.ID,
                    Naziv=x.Naziv,
                    Lokacija=x.Lokacija,
                    RadnoVrijemeDo=x.RadnoVrijemeDo,
                    RadnoVrijemeOd=x.RadnoVrijemeOd,
                    Opis=x.Opis,
                    SlikaRestorana=null,
                    ImePrezimeVlasnika=x.VlasnikRestorana.Ime+" "+x.VlasnikRestorana.Prezime
                }).ToListAsync();

            return new GetRestoraniResponse
            {
                Restorani = restoran,
                BrojRestorana=restoran.Count(),
            };


        }
    }
}
