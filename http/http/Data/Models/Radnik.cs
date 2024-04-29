﻿using System.ComponentModel.DataAnnotations.Schema;

namespace http.Data.Models
{
    [Table("Radnik")]

    public class Radnik:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string BrojTelefona { get; set; }

    }
}
