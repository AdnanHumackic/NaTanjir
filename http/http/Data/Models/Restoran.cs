﻿using System.ComponentModel.DataAnnotations.Schema;

namespace http.Data.Models
{
    public class Restoran
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string RadnoVrijemeOd { get; set; }
        public string RadnoVrijemeDo { get; set; }
        public string Opis { get; set; }
        public string? SlikaRestorana { get; set; }
        public bool isObrisan { get; set; }
        public string Lokacija { get; set; }
        [ForeignKey(nameof(VlasnikRestorana))]
        public int VlasnikRestoranaID { get; set; }
        public Vlasnik VlasnikRestorana { get; set; }

    }
}
