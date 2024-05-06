namespace http.Endpoint.Vlasnik.GetKategorijeProizvoda
{
    

    public class GetKategorijeProizvodaResponse
    {
        public List<GetKategorijeProizvodaResponseKategorije> Kategorije { get; set; }
    }
    public class GetKategorijeProizvodaResponseKategorije
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
