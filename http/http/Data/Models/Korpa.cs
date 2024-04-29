using System.ComponentModel.DataAnnotations.Schema;

namespace http.Data.Models
{
    public class Korpa
    {
        public int ID { get; set; }
        public int Kolicina { get; set; }
        public float UkupnaCijena { get; set; }

        [ForeignKey(nameof(Proizvod))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int EvidentiraoKorisnikID { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
