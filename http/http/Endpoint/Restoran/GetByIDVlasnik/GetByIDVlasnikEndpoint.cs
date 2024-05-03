using http.Data;
using http.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace http.Endpoint.Restoran.GetByIDVlasnik
{
    [Route("Restoran-GetByIDVlasnik")]
    public class GetByIDVlasnikEndpoint:MyBaseEndpoint<GetByIDVlasnikRequest, GetByIDVlasnikResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GetByIDVlasnikEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<GetByIDVlasnikResponse> Akcija([FromQuery]GetByIDVlasnikRequest request, CancellationToken cancellationToken)
        {
            var restoran = await _applicationDbContext.Restoran
                .Where(x => x.VlasnikRestoranaID == request.ID)
                .Select(x => new GetByIDVlasnikResponseRestoran
                {
                    ID=x.ID,
                    Naziv=x.Naziv,
                    Opis=x.Opis,
                    RadnoVrijemeOd=x.RadnoVrijemeOd,
                    RadnoVrijemeDo=x.RadnoVrijemeDo,
                    SlikaRestorana=x.SlikaRestorana
                }).ToListAsync();

            return new GetByIDVlasnikResponse
            {
                Restoran = restoran
            };
        }
    }
}
