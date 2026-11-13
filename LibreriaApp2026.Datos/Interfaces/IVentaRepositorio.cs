using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IVentaRepositorio : IRepositorioConcurrente<Venta>
    {
        //con seguimiento de cambios, para facturar o anular
        Venta? ObtenerConDetalles(int id);
        //sin seguimiento, para mostrar el detalle
        Venta? ObtenerParaConsulta(int id);
        //libros (con su editorial) que se quieren vender, con seguimiento para descontar el stock
        List<Libro> ObtenerLibros(IEnumerable<int> ids);
        //catálogo de libros que se pueden vender, sin seguimiento
        List<Libro> ObtenerLibrosParaVenta(string? textoBuscar);
    }
}
