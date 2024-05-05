using http.Data;
using http.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace http.Endpoint.Vlasnik.UpdateRestoran
{
    [Route("Vlasnik-UpdateRestoran")]
    public class UpdateRestoranEndpoint:MyBaseEndpoint<UpdateRestoranRequest, NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UpdateRestoranEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<NoResponse> Akcija([FromBody]UpdateRestoranRequest request, CancellationToken cancellationToken)
        {
            var restoran = await _applicationDbContext.Restoran.Where(x => x.ID == request.ID).FirstOrDefaultAsync();

            if (restoran == null)
            {
                throw new Exception("Nije pronađen restoran za ID: " + request.ID);
            }

            restoran.ID = request.ID;
            restoran.Naziv = request.Naziv;
            restoran.Opis = request.Opis;
            restoran.RadnoVrijemeOd = request.RadnoVrijemeOd;
            restoran.RadnoVrijemeDo = request.RadnoVrijemeDo;
            restoran.Lokacija = request.Lokacija;
            restoran.SlikaRestorana = request.SlikaRestorana != null 
                ? SlikaHelper.SacuvajSlike(request.SlikaRestorana, request.ID)
                : null;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new NoResponse();
        }
    }
}
