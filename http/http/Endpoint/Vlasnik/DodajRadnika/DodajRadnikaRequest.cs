namespace http.Endpoint.Vlasnik.DodajRadnika
{
    public class DodajRadnikaRequest
    {
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string BrojTelefona { get; set; }
        public int RestoranID { get; set; }
    }
    
}
