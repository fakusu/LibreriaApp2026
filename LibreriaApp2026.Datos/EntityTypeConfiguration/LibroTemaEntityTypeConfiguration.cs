using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class LibroTemaEntityTypeConfiguration : IEntityTypeConfiguration<LibroTema>
    {
        public void Configure(EntityTypeBuilder<LibroTema> builder)
        {
            builder.ToTable("LibrosTemas");
            builder.HasKey(lt => new { lt.ProductoId, lt.TemaId });

            builder.HasOne(lt => lt.Libro)
                .WithMany(l => l.LibrosTemas)
                .HasForeignKey(lt => lt.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(lt => lt.Tema)
                .WithMany()
                .HasForeignKey(lt => lt.TemaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
