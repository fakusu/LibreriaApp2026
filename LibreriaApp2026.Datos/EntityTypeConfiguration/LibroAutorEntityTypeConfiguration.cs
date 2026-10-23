using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class LibroAutorEntityTypeConfiguration : IEntityTypeConfiguration<LibroAutor>
    {
        public void Configure(EntityTypeBuilder<LibroAutor> builder)
        {
            builder.ToTable("LibrosAutores");
            builder.HasKey(la => new { la.ProductoId, la.AutorId });

            builder.HasOne(la => la.Libro)
                .WithMany(l => l.LibrosAutores)
                .HasForeignKey(la => la.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(la => la.Autor)
                .WithMany()
                .HasForeignKey(la => la.AutorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
