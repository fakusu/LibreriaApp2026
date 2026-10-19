using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class LibroFisicoEntityTypeConfiguration : IEntityTypeConfiguration<LibroFisico>
    {
        public void Configure(EntityTypeBuilder<LibroFisico> builder)
        {
            builder.ToTable("LibrosFisicos");
            builder.Property(l => l.PesoEnGramos).IsRequired();
            builder.Property(l => l.CantidadPaginas).IsRequired();
        }
    }
}
