using http.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace http.Endpoint.Vlasnik.DodajHranu
{
    public class DodajProizvodRequest
    {
        public int ID { get; set; }
        public string NazivProizvoda { get; set; }
        public string CijenaProizvoda { get; set; }
        public string Sastojci { get; set; }
        public bool IsUPonudi { get; set; }
        public string VrijemePripreme { get; set; }
        public string? SlikaProizvoda { get; set; }

        public int KategorijaID { get; set; }

        public int RestoranID { get; set; }
    }
}
