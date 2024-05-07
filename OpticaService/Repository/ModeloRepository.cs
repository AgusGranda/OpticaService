using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using OpticaService.DataAccess;
using OpticaService.Models;

namespace OpticaService.Repository
{
    public class ModeloRepository : IModeloRepository
    {

        private readonly MyDbContext _dbContext;


        public ModeloRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Modelo>> GetAllModelos()
        {
            return await _dbContext.Modelos.ToListAsync();
        }

        public async Task<Modelo> GetModeloById(int id)
        {
            return await _dbContext.Modelos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task PostModelo(Modelo modelo)
        {
            await _dbContext.Modelos.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutModelo(Modelo modelo)
        {
            _dbContext.Modelos.Update(modelo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteModelo(int id)
        {
            var modelo = await _dbContext.Modelos.FirstOrDefaultAsync(x => x.Id == id);
            if (modelo != null)
            {
                modelo.Estado = false;
                _dbContext.Update(modelo);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
