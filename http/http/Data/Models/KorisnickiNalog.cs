using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace http.Data.Models
{
    [Table("KorisnickiNalog")]

    public class KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }

        [JsonIgnore]
        public string Lozinka { get; set; }
        public string? SlikaKorisnika { get; set; }

        [JsonIgnore]
        public Kupac? Kupac => this as Kupac;

        [JsonIgnore]
        public Radnik? Radnik => this as Radnik;
        [JsonIgnore]
        public Vlasnik? Vlasnik => this as Vlasnik;

        [JsonIgnore]
        public Admin? Admin => this as Admin;
        public bool isKupac => Kupac != null;
        public bool isRadnik => Radnik != null;
        public bool isVlasnik => Vlasnik != null;

        public bool isAdmin => Admin != null;
        public bool Is2FActive { get; set; }
    }
}
