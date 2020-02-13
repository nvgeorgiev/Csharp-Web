namespace IRunes.Data
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;

    public class RunesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=DESKTOP-NN6P8LO\SQLEXPRESS01;Database=IRunes;Integrated Security=true");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Album> Albums { get; set; }
    }
}
