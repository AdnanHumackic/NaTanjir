using http.Data;
using http.Helper;
using http.Helper.Auth;
using Microsoft.AspNetCore.Mvc;

namespace http.Endpoint.Admin.DodajVlasnika
{
    [Route("Admin-DodajVlasnika")]
    public class DodajVlasnikaEndpoint:MyBaseEndpoint<DodajVlasnikaRequest,NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public DodajVlasnikaEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
            _myAuthService = myAuthService;
        }

        [HttpPost]
        public override async Task<NoResponse> Akcija([FromBody]DodajVlasnikaRequest request, CancellationToken cancellationToken)
        {
            var vlasnik = new Data.Models.Vlasnik
            {
                ID = request.ID,
                Ime = request.Ime,
                Prezime = request.Prezime,
                KorisnickoIme = request.KorisnickoIme,
                Lozinka = request.Lozinka,
                BrojTelefona = request.BrojTelefona,
                Email = request.Email,
                DatumRodjenja = request.DatumRodjenja,
                Is2FActive = false,
            };

            _applicationDbContext.Add(vlasnik);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new NoResponse();
        }
    }
}
