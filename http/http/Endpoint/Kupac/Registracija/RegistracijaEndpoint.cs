using http.Data;
using http.Helper;
using Microsoft.AspNetCore.Mvc;

namespace http.Endpoint.Kupac.Registracija
{
    [Route("Kupac-Registracija")]
    public class RegistracijaEndpoint:MyBaseEndpoint<RegistracijaRequest, NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RegistracijaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<NoResponse> Akcija([FromBody]RegistracijaRequest request, CancellationToken cancellationToken)
        {
            var kupac = new Data.Models.Kupac
            {
                ID = request.ID,
                Ime = request.Ime,
                Prezime = request.Prezime,
                KorisnickoIme = request.KorisnickoIme,
                Lozinka = request.Lozinka,
                Email = request.Email,
                BrojTelefona = request.BrojTelefona,
                DatumRodjenja = request.DatumRodjenja,
                Is2FActive = false,
                SlikaKorisnika=null,
            };

            _applicationDbContext.Add(kupac);
            await _applicationDbContext.SaveChangesAsync();

            return new NoResponse();
        }
    }
}
