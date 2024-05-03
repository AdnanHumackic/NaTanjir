using http.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace http.Endpoint.Restoran.GetByIDVlasnik
{
    public class GetByIDVlasnikResponse 
    {
        public List<GetByIDVlasnikResponseRestoran> Restoran { get; set; }
    }
    public class GetByIDVlasnikResponseRestoran
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string RadnoVrijemeOd { get; set; }
        public string RadnoVrijemeDo { get; set; }
        public string Opis { get; set; }
        public string? SlikaRestorana { get; set; }
    }
}
