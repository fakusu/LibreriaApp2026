using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos
{
    public class LibreriaDbContext : DbContext
    {
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Tema> Temas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LibreriaIo2026;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibreriaDbContext).Assembly);
        }
    }
}
