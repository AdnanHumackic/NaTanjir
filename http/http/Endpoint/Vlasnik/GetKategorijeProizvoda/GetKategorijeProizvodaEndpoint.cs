using http.Data;
using http.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace http.Endpoint.Vlasnik.GetKategorijeProizvoda
{
    [Route("Vlasnik-GetKategorijeProizvoda")]
    public class GetKategorijeProizvodaEndpoint:MyBaseEndpoint<NoRequest, GetKategorijeProizvodaResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GetKategorijeProizvodaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<GetKategorijeProizvodaResponse> Akcija([FromQuery]NoRequest request, CancellationToken cancellationToken)
        {
            var kategorije = await _applicationDbContext
                .KategorijaProizvoda
                .Select(x => new GetKategorijeProizvodaResponseKategorije
                {
                    ID=x.ID,
                    Naziv=x.NazivKategorije
                }).ToListAsync();

            return new GetKategorijeProizvodaResponse
            {
                Kategorije= kategorije
            };

        }
    }
}
