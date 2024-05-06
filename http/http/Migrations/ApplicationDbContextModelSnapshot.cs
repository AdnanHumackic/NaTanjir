﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using http.Data;

#nullable disable

namespace http.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("http.Data.Models.AutentifikacijaToken", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Is2FOtkljucano")
                        .HasColumnType("bit");

                    b.Property<int>("KorisnickiNalogID")
                        .HasColumnType("int");

                    b.Property<string>("TwoFKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrijednost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ipAdresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("KorisnickiNalogID");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("http.Data.Models.Dostava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("CijenaDostave")
                        .HasColumnType("real");

                    b.Property<int>("RestoranID")
                        .HasColumnType("int");

                    b.Property<string>("TelefonskiBrojDostavljaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RestoranID");

                    b.ToTable("Dostava");
                });

            modelBuilder.Entity("http.Data.Models.KategorijaProizvoda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NazivKategorije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("KategorijaProizvoda");
                });

            modelBuilder.Entity("http.Data.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Is2FActive")
                        .HasColumnType("bit");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaKorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("KorisnickiNalog");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("http.Data.Models.Korpa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("EvidentiraoKorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.Property<float>("UkupnaCijena")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("EvidentiraoKorisnikID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("Korpa");
                });

            modelBuilder.Entity("http.Data.Models.Narudzba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdresaIsporuke")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("EvidentiraoKorisnikID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDostavljeno")
                        .HasColumnType("bit");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("UkupnaCijena")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("EvidentiraoKorisnikID");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("http.Data.Models.Proizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CijenaProizvoda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUPonudi")
                        .HasColumnType("bit");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("NazivProizvoda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestoranID")
                        .HasColumnType("int");

                    b.Property<string>("Sastojci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaProizvoda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VrijemePripreme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("RestoranID");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("http.Data.Models.Restoran", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Lokacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RadnoVrijemeDo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RadnoVrijemeOd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaRestorana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VlasnikRestoranaID")
                        .HasColumnType("int");

                    b.Property<bool>("isObrisan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("VlasnikRestoranaID");

                    b.ToTable("Restoran");
                });

            modelBuilder.Entity("http.Data.Models.Admin", b =>
                {
                    b.HasBaseType("http.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("http.Data.Models.Kupac", b =>
                {
                    b.HasBaseType("http.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("http.Data.Models.Radnik", b =>
                {
                    b.HasBaseType("http.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestoranID")
                        .HasColumnType("int");

                    b.HasIndex("RestoranID");

                    b.ToTable("Radnik");
                });

            modelBuilder.Entity("http.Data.Models.Vlasnik", b =>
                {
                    b.HasBaseType("http.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Vlasnik");
                });

            modelBuilder.Entity("http.Data.Models.AutentifikacijaToken", b =>
                {
                    b.HasOne("http.Data.Models.KorisnickiNalog", "korisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("korisnickiNalog");
                });

            modelBuilder.Entity("http.Data.Models.Dostava", b =>
                {
                    b.HasOne("http.Data.Models.Restoran", "Restoran")
                        .WithMany()
                        .HasForeignKey("RestoranID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restoran");
                });

            modelBuilder.Entity("http.Data.Models.Korpa", b =>
                {
                    b.HasOne("http.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("EvidentiraoKorisnikID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("http.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("KorisnickiNalog");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("http.Data.Models.Narudzba", b =>
                {
                    b.HasOne("http.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("EvidentiraoKorisnikID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("KorisnickiNalog");
                });

            modelBuilder.Entity("http.Data.Models.Proizvod", b =>
                {
                    b.HasOne("http.Data.Models.KategorijaProizvoda", "KategorijaProizvoda")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("http.Data.Models.Restoran", "Restoran")
                        .WithMany()
                        .HasForeignKey("RestoranID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("KategorijaProizvoda");

                    b.Navigation("Restoran");
                });

            modelBuilder.Entity("http.Data.Models.Restoran", b =>
                {
                    b.HasOne("http.Data.Models.Vlasnik", "VlasnikRestorana")
                        .WithMany()
                        .HasForeignKey("VlasnikRestoranaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VlasnikRestorana");
                });

            modelBuilder.Entity("http.Data.Models.Admin", b =>
                {
                    b.HasOne("http.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("http.Data.Models.Admin", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("http.Data.Models.Kupac", b =>
                {
                    b.HasOne("http.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("http.Data.Models.Kupac", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("http.Data.Models.Radnik", b =>
                {
                    b.HasOne("http.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("http.Data.Models.Radnik", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("http.Data.Models.Restoran", "Restoran")
                        .WithMany()
                        .HasForeignKey("RestoranID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Restoran");
                });

            modelBuilder.Entity("http.Data.Models.Vlasnik", b =>
                {
                    b.HasOne("http.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("http.Data.Models.Vlasnik", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
