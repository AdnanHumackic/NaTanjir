using System.ComponentModel.DataAnnotations.Schema;

namespace http.Endpoint.Vlasnik.UpdateRestoran
{
    public class UpdateRestoranRequest
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string RadnoVrijemeOd { get; set; }
        public string RadnoVrijemeDo { get; set; }
        public string Opis { get; set; }
        public string? SlikaRestorana { get; set; }
        public string Lokacija { get; set; }
    }
}
