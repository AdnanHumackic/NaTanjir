using http.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace http.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Dostava>Dostava { get; set; }
        public DbSet<KategorijaProizvoda> KategorijaProizvoda { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Korpa> Korpa { get; set; }
        public DbSet<Kupac> Kupac { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Radnik> Radnik { get; set; }
        public DbSet<Restoran> Restoran { get; set; }
        public DbSet<Vlasnik> Vlasnik { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }

        public ApplicationDbContext(
        DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
