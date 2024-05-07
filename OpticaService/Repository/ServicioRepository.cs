using Microsoft.EntityFrameworkCore;
using OpticaService.DataAccess;
using OpticaService.Models;

namespace OpticaService.Repository
{
    public class ServicioRepository : IServicioRepository
    {
       
        private readonly MyDbContext _dbContext;

        public ServicioRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Servicio>> GetAllServicio()
        {
            return await _dbContext.Servicios.ToListAsync();
        }

        public async Task<Servicio> GetServicioById(int id)
        {
            return await _dbContext.Servicios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task PostServicio(Servicio servicio)
        {
            await _dbContext.Servicios.AddAsync(servicio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutServicio(Servicio servicio)
        {
            _dbContext.Servicios.Update(servicio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteServicio(int id)
        {
            var servicio = await _dbContext.Servicios.FirstOrDefaultAsync(x => x.Id == id);
            if (servicio != null)
            {
                servicio.Estado = false;
                _dbContext.Servicios.Update(servicio);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
