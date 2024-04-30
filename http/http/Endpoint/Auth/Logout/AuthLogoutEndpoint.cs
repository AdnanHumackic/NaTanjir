using http.Data;
using http.Data.Models;
using http.Helper;
using http.Helper.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace http.Endpoint.Auth.Logout
{
    [Route("Auth")]
    public class AuthLogoutEndpoint : MyBaseEndpoint<AuthLogoutRequest, NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;

        public AuthLogoutEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }


        [HttpPost("Logout")]
        public override async Task<NoResponse> Akcija([FromBody]AuthLogoutRequest request, CancellationToken cancellationToken)
        {
            AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

            if (autentifikacijaToken == null)
                return new NoResponse();

            _applicationDbContext.Remove(autentifikacijaToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new NoResponse();
        }
    }
}
