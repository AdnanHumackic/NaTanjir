using http.Data;
using http.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace http.Endpoint.GeneratorPodataka
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PodaciController:ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PodaciController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public ActionResult Count()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            data.Add("Kupac", _applicationDbContext.Kupac.Count());
            data.Add("Admin", _applicationDbContext.Admin.Count());
            data.Add("Vlasnik", _applicationDbContext.Vlasnik.Count());
            data.Add("Kategorija", _applicationDbContext.KategorijaProizvoda.Count());
            return Ok(data);
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            var kupac = new List<Data.Models.Kupac>();
            var admin = new List<Data.Models.Admin>();
            var vlasnik = new List<Data.Models.Vlasnik>();
            var kategorija = new List<Data.Models.KategorijaProizvoda>();
            
            kupac.Add(new Data.Models.Kupac
            {
                Is2FActive = false,
                Ime = "Kupac",
                Prezime = "Tester",
                KorisnickoIme = "kupac",
                Lozinka = "test",
                SlikaKorisnika = null,
                DatumRodjenja = DateTime.Now,
                BrojTelefona="061-321-123",
                Email="kupac@tester.com"
            });
            admin.Add(new Data.Models.Admin
            {
                Is2FActive = false,
                Ime = "Admin",
                Prezime = "Tester",
                KorisnickoIme = "admin",
                Lozinka = "test",
                SlikaKorisnika = null,
                DatumRodjenja = DateTime.Now,
                DatumZaposlenja = DateTime.Now,
                BrojTelefona="061-222-333",
                Email="admin@tester.com"
            });
            vlasnik.Add(new Data.Models.Vlasnik
            {
                Is2FActive = false,
                Ime = "Vlasnik",
                Prezime = "Tester",
                KorisnickoIme = "vlasnik",
                Lozinka = "test",
                SlikaKorisnika = null,
                DatumRodjenja = DateTime.Now,
                BrojTelefona = "061-123-321",
                Email = "vlasnik@tester.com"
            });
            kategorija.Add(new Data.Models.KategorijaProizvoda
            {
                NazivKategorije = "Sendvić"
            });

            kategorija.Add(new Data.Models.KategorijaProizvoda
            {
                NazivKategorije = "Kolač"
            });
            kategorija.Add(new Data.Models.KategorijaProizvoda
            {
                NazivKategorije = "Pizza"
            });
            _applicationDbContext.AddRange(admin);
            _applicationDbContext.AddRange(kupac);
            _applicationDbContext.AddRange(vlasnik);
            _applicationDbContext.AddRange(kategorija);
            _applicationDbContext.SaveChanges();

            return Count();

        }
    }
}
