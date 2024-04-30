using http.Data;
using http.Data.Models;
using http.Helper;
using http.Helper.Auth;
using Microsoft.AspNetCore.Mvc;

namespace http.Endpoint.Auth.Get
{
    [Route("Auth")]
    public class AuthGetEndpoint:MyBaseEndpoint<NoRequest, MyAuthInfo>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;

        public AuthGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }

        [HttpPost("Get")]
        public override async Task<MyAuthInfo> Akcija([FromBody]NoRequest request, CancellationToken cancellationToken)
        {
            AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

            return new MyAuthInfo(autentifikacijaToken);
        }
    }
}
