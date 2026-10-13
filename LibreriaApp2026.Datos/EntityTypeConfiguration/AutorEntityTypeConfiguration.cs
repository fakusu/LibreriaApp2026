using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class AutorEntityTypeConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");
            builder.HasKey(a => a.AutorId);
            builder.Property(a => a.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Apellido).IsRequired().HasMaxLength(50);
            builder.Property(a => a.FechaNacimiento).IsRequired().HasColumnType("date");
            builder.Property(a => a.Nacionalidad).IsRequired().HasMaxLength(50);
            builder.HasIndex(a => new { a.Apellido, a.Nombre }, "IX_Autores_Apellido_Nombre").IsUnique();
        }
    }
}
