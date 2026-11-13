using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.ClienteId);
            builder.Property(c => c.RowVersion).IsRowVersion();
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Apellido).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Documento).IsRequired().HasMaxLength(8);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.Telefono).HasMaxLength(30);
            builder.Property(c => c.Calle).HasMaxLength(100);
            builder.Property(c => c.Numero).HasMaxLength(20);
            builder.Property(c => c.Localidad).HasMaxLength(100);
            builder.Property(c => c.Provincia).HasMaxLength(100);
            builder.Property(c => c.CodigoPostal).HasMaxLength(10);
            builder.Ignore(c => c.NombreCompleto);
            builder.HasIndex(c => c.Documento, "IX_Clientes_Documento").IsUnique();
        }
    }
}
