using Microsoft.EntityFrameworkCore;

namespace Test0106
{
    public class ErettsegiDbContext : DbContext
    {
        public ErettsegiDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Database=erettsegi;User=root;Password=;";
                optionsBuilder.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                );
            }
        }

        public DbSet<Tanar> Tanar { get; set; }
        public DbSet<Vizsgak> Vizsgak { get; set; }
        public DbSet<Vizsgazo> Vizsgazo { get; set; }
    }

    public class Vizsgazo
    {
        public int Id { get; set; }
        public string DiakNev { get; set; }
        public int Evfolyam { get; set; }
        public string Osztaly { get; set; }
    }

    public class Vizsgak
    {
        public int Id { get; set; }
        public string VizsgaTargy { get; set; }
        public int VizsgazoId { get; set; }
        public string TanarId { get; set; }
    }

    public class Tanar
    {
        public string Id { get; set; }
        public string Nev { get; set; }
    }
}
