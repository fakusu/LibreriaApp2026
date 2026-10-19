using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class LibroDigitalEntityTypeConfiguration : IEntityTypeConfiguration<LibroDigital>
    {
        public void Configure(EntityTypeBuilder<LibroDigital> builder)
        {
            builder.ToTable("LibrosDigitales");
            builder.Property(l => l.Formato).IsRequired().HasMaxLength(10);
            builder.Property(l => l.TamanioMB).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(l => l.UrlDescarga).IsRequired().HasMaxLength(300);
        }
    }
}
