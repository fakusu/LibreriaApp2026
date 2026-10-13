using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class EditorialEntityTypeConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("Editoriales");
            builder.HasKey(e => e.EditorialId);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(e => e.PaisOrigen).IsRequired().HasMaxLength(50);
            builder.HasIndex(e => e.Nombre, "IX_Editoriales_Nombre").IsUnique();
        }
    }
}
