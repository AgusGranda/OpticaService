using Microsoft.EntityFrameworkCore;
using OpticaService.DataAccess;
using OpticaService.Models;

namespace OpticaService.Repository
{
    public class VentaRepository : IVentaRepository
    {
        
        private readonly MyDbContext _dbContext;

        public VentaRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Venta>> GetAllVentas()
        {
            return await _dbContext.Ventas.ToListAsync();
        }

        public async Task<Venta> GetVentaById(int id)
        {
            return await _dbContext.Ventas.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task PostVenta(Venta venta)
        {
            await _dbContext.Ventas.AddAsync(venta);
            await _dbContext.SaveChangesAsync();

        }

        public async Task PutVenta(Venta venta)
        {
            _dbContext.Ventas.Update(venta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteVenta(int id)
        {
            var venta = await _dbContext.Ventas.FirstOrDefaultAsync(x => x.Id == id);
            if (venta != null)
            {
                _dbContext.Remove(venta);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
