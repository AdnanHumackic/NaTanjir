using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace http.Data.Models
{
    public class Narudzba
    {
        public int ID { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public float UkupnaCijena { get; set; }
        public int Kolicina { get; set; }
        public string? Napomena { get; set; }
        public bool IsDostavljeno { get; set; }
        public string AdresaIsporuke { get; set; }


        [ForeignKey(nameof(KorisnickiNalog))]
        public int EvidentiraoKorisnikID { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        
    }
}
