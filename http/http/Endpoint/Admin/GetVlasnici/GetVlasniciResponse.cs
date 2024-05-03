namespace http.Endpoint.Admin.GetVlasnici
{
    public class GetVlasniciResponse
    {
        public List<GetVlasniciResponseVlasnici> Vlasnik { get; set; }
    }
    public class GetVlasniciResponseVlasnici
    {
        public int ID { get; set; }
        public string ImePrezime { get; set; }
    }
}
