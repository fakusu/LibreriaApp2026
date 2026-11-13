using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class DetalleVentaEntityTypeConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetallesVentas");
            builder.HasKey(d => new { d.VentaId, d.ProductoId });
            builder.Property(d => d.Cantidad).IsRequired();
            builder.Property(d => d.PrecioUnitario).IsRequired().HasColumnType("decimal(18,2)");
            builder.Ignore(d => d.Subtotal);

            builder.HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
