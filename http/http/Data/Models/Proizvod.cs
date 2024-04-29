using System.ComponentModel.DataAnnotations.Schema;

namespace http.Data.Models
{
    public class Proizvod
    {
        public int ID { get; set; }
        public string NazivProizvoda { get; set; }
        public float CijenaProizvoda { get; set; }
        public string Sastojci { get; set; }
        public bool IsUPonudi { get; set; }
        public float VrijemePripreme { get; set; }
        public string? SlikaProizvoda { get; set; }

        [ForeignKey(nameof(KategorijaProizvoda))]
        public int KategorijaID { get;set; }
        public KategorijaProizvoda KategorijaProizvoda { get; set; }

        [ForeignKey(nameof(Restoran))]
        public int RestoranID { get; set; }
        public Restoran Restoran { get; set; }


    }
}
