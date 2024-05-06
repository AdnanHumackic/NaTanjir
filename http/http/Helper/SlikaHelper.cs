namespace http.Helper
{
    public static class SlikaHelper
    {
        public static string UpdateImage(string slika, int id, string folder)
        {
            if (string.IsNullOrEmpty(slika))
                throw new Exception("Slika nije pronađena.");

            byte[] slikaBajtovi = slika.ParsirajBase64();
            if (slikaBajtovi == null)
                throw new Exception("Pogrešan base64 format.");

            byte[] slikaBajtoviResizedVelika = SlikaResize.Resize(slikaBajtovi, 200);
            if (slikaBajtoviResizedVelika == null)
                throw new Exception("Pogrešan format slike.");

            byte[] slikaBajtoviResizedMala = SlikaResize.Resize(slikaBajtovi, 50);
            if (slikaBajtoviResizedMala == null)
                throw new Exception("Pogrešan format slike.");

            string folderPath = folder;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string putanjaVelikaSlika = $"{folderPath}/{id}-velika.jpg";
            string putanjaMalaSlika = $"{folderPath}/{id}-mala.jpg";

            File.WriteAllBytes(putanjaVelikaSlika, slikaBajtoviResizedVelika);
            File.WriteAllBytes(putanjaMalaSlika, slikaBajtoviResizedMala);

            return putanjaVelikaSlika;
        }

    }
}
