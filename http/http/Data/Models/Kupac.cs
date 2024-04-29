using System.ComponentModel.DataAnnotations.Schema;

namespace http.Data.Models
{
    [Table("Kupac")]
    public class Kupac:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get;set; }
        
        public DateTime DatumRodjenja { get; set; }
    }
}
