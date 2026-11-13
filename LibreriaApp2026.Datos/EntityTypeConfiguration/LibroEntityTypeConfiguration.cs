using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class LibroEntityTypeConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libros");
            //al leer de la base EF usa el campo y no el setter, así un ISBN viejo con otro formato no impide listar
            builder.Property(l => l.ISBN).IsRequired().HasMaxLength(13).HasField("_isbn");
            builder.Property(l => l.AnioPublicacion).IsRequired();
            builder.Property(l => l.Precio).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(l => l.EditorialId).IsRequired();
            builder.HasIndex(l => l.ISBN, "IX_Libros_ISBN").IsUnique();

            builder.HasOne(l => l.Editorial)
                .WithMany()
                .HasForeignKey(l => l.EditorialId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
