 namespace http.Endpoint.Kupac.GetRestorani
{
    public class GetRestoraniResponse
    {
        public List<GetRestoraniResponseRestorani> Restorani { get; set; }
        public int BrojRestorana { get; set; }
    }
    public class GetRestoraniResponseRestorani
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string RadnoVrijemeOd { get; set; }
        public string RadnoVrijemeDo { get; set; }
        public string Opis { get; set; }
        public string? SlikaRestorana { get; set; }
        public bool isObrisan { get; set; }
        public string Lokacija { get; set; }
        public string ImePrezimeVlasnika { get; set; }
    }
}
