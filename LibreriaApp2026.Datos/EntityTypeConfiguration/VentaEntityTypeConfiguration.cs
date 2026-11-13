using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreriaApp2026.Datos.EntityTypeConfiguration
{
    public class VentaEntityTypeConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Ventas");
            builder.HasKey(v => v.VentaId);
            builder.Property(v => v.VentaId).ValueGeneratedOnAdd();
            builder.Property(v => v.RowVersion).IsRowVersion();
            builder.Property(v => v.FechaVenta).IsRequired();
            builder.Property(v => v.EstadoVenta).IsRequired().HasConversion<byte>();
            builder.Property(v => v.ImporteTotal).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.FormaDePago)
                .WithMany(f => f.Ventas)
                .HasForeignKey(v => v.FormaDePagoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(v => v.Detalles)
                .WithOne(d => d.Venta)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.Restrict);

            //EF carga y guarda los detalles a través de la lista privada _detalles
            builder.Navigation(v => v.Detalles)
                .HasField("_detalles")
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
