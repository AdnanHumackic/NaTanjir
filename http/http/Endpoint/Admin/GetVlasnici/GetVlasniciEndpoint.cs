using http.Data;
using http.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace http.Endpoint.Admin.GetVlasnici
{
    [Route("Admin-GetVlasnici")]
    public class GetVlasniciEndpoint:MyBaseEndpoint<NoRequest,GetVlasniciResponse   > 
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GetVlasniciEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<GetVlasniciResponse> Akcija([FromQuery]NoRequest request, CancellationToken cancellationToken)
        {
            var vlasnik = await _applicationDbContext.Vlasnik
                .Select(x => new GetVlasniciResponseVlasnici
                {
                    ID=x.ID,
                    ImePrezime=x.Ime+" "+x.Prezime
                }).ToListAsync();

            return new GetVlasniciResponse
            {
                Vlasnik = vlasnik
            };
        }
    }
}
