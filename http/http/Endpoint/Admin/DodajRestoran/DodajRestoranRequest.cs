using http.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace http.Endpoint.Admin.DodajRestoran
{
    public class DodajRestoranRequest
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string RadnoVrijemeOd { get; set; }
        public string RadnoVrijemeDo { get; set; }
        public string Opis { get; set; }
        public int VlasnikRestoranaID { get; set; }
        public string Lokacija { get; set; }
    }
}
