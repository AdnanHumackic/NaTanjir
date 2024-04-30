using http.Data;
using http.Data.Models;
using http.Helper;
using http.Helper.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace http.Endpoint.Auth.Login
{
    [Route("Auth")]
    public class AuthLoginEndpoint:MyBaseEndpoint<AuthLoginRequest, MyAuthInfo>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthLoginEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost("Login")]

        public override async Task<MyAuthInfo> Akcija([FromBody]AuthLoginRequest request, CancellationToken cancellationToken)
        {
            Data.Models.KorisnickiNalog? logiraniKorisnik = await _applicationDbContext.KorisnickiNalog
                .FirstOrDefaultAsync(k =>
                    k.KorisnickoIme == request.KorisnickoIme && k.Lozinka == request.Lozinka);

            if (logiraniKorisnik == null)
            {
                return new MyAuthInfo(null);
            }

            string? twoFKey = null;


            string randomString = TokenGenerator.Generate();

            var noviToken = new AutentifikacijaToken()
            {
                ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Vrijednost = randomString,
                korisnickiNalog = logiraniKorisnik,
                vrijemeEvidentiranja = DateTime.Now,
                TwoFKey = twoFKey
            };

            _applicationDbContext.Add(noviToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new MyAuthInfo(noviToken);
        }
    }
}
