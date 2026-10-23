using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class TemaEntityTypeConfiguration : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.ToTable("Temas");
            builder.HasKey(t => t.TemaId);
            builder.Property(t => t.RowVersion).IsRowVersion();
            builder.Property(t => t.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Descripcion).HasMaxLength(200);
            builder.HasIndex(t => t.Nombre, "IX_Temas_Nombre").IsUnique();
        }
    }
}
