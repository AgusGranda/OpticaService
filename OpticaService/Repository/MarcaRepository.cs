using Microsoft.EntityFrameworkCore;
using OpticaService.DataAccess;
using OpticaService.Models;

namespace OpticaService.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly MyDbContext _dbContext;

        public MarcaRepository(MyDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Marca>> GetAllMarcas()
        {
            return await _dbContext.Marcas.ToListAsync();
        }

        public async Task<Marca> GetMarcaById(int id)
        {
            return await _dbContext.Marcas.FirstAsync(x => x.Id == id);
        }

        public async Task PostMarca(Marca marca)
        {
            await _dbContext.Marcas.AddAsync(marca);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutMarca(Marca marca)
        {
            _dbContext.Marcas.Update(marca);
            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteMarca(int id)
        {
            var marca = await _dbContext.Marcas.FirstOrDefaultAsync(x => x.Id == id);
            if (marca != null)
            {   
                marca.Estado = false;
                _dbContext.Marcas.Update(marca);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
