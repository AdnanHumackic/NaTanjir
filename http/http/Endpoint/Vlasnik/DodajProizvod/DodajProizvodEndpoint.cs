using http.Data;
using http.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace http.Endpoint.Vlasnik.DodajHranu
{
    [Route("Vlasnik-DodajHranu")]
    public class DodajProizvodEndpoint:MyBaseEndpoint<DodajProizvodRequest, NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DodajProizvodEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<NoResponse> Akcija([FromBody] DodajProizvodRequest request, CancellationToken cancellationToken)
        {
            string folderPath = "slike-hrane";

            var noviProizvod = new Data.Models.Proizvod
            {
                ID = request.ID,
                RestoranID = request.RestoranID,
                CijenaProizvoda = request.CijenaProizvoda,
                KategorijaID = request.KategorijaID,
                NazivProizvoda = request.NazivProizvoda,
                Sastojci = request.Sastojci,
                IsUPonudi = request.IsUPonudi,
                VrijemePripreme = request.VrijemePripreme,
                SlikaProizvoda=null
            };
           
            _applicationDbContext.Proizvod.Add(noviProizvod);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            noviProizvod.SlikaProizvoda = request.SlikaProizvoda != null
               ? SlikaHelper.UpdateImage(request.SlikaProizvoda, noviProizvod.ID, folderPath)
               : null;
            _applicationDbContext.Proizvod.Update(noviProizvod);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);


            return new NoResponse();
        }
    }
}
