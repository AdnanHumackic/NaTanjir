using System.ComponentModel.DataAnnotations.Schema;

namespace http.Data.Models
{
    public class Dostava
    {
        public int ID { get; set; }
        public float CijenaDostave { get; set; }
        public string TelefonskiBrojDostavljaca { get; set; }

        [ForeignKey(nameof(Restoran))]
        public int RestoranID { get; set; }
        public Restoran Restoran { get; set; }
    }
}
