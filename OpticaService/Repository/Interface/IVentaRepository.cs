using OpticaService.Models;

namespace OpticaService.Repository
{
    public interface IVentaRepository
    {
        Task<IEnumerable<Venta>> GetAllVentas();
        Task<Venta> GetVentaById(int id);
        Task PostVenta(Venta venta);
        Task PutVenta(Venta venta);
        Task DeleteVenta(int id);
    }
}
