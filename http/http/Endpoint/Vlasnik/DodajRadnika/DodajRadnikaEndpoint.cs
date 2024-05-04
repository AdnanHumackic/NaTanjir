using http.Data;
using http.Helper;
using Microsoft.AspNetCore.Mvc;

namespace http.Endpoint.Vlasnik.DodajRadnika
{
    [Route("Vlasnik-DodajRadnika")]
    public class DodajRadnikaEndpoint:MyBaseEndpoint<DodajRadnikaRequest, NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DodajRadnikaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<NoResponse> Akcija([FromBody]DodajRadnikaRequest request, CancellationToken cancellationToken)
        {
            var radnik = new Data.Models.Radnik
            {
                ID = request.ID,
                Ime = request.Ime,
                Prezime = request.Prezime,
                KorisnickoIme = request.KorisnickoIme,
                Lozinka = request.Lozinka,
                DatumRodjenja = request.DatumRodjenja,
                DatumZaposlenja = request.DatumZaposlenja,
                Is2FActive = false,
                SlikaKorisnika=null,
                BrojTelefona=request.BrojTelefona,
                RestoranID=request.RestoranID,
                Email=request.Email
            };

            _applicationDbContext.Add(radnik);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new NoResponse();
        }
    }
}
