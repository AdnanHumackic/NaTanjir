namespace http.Endpoint.Admin.DodajVlasnika
{
    public class DodajVlasnikaRequest
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
    }
}
