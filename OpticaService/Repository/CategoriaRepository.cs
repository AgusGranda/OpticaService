using Microsoft.EntityFrameworkCore;
using OpticaService.DataAccess;
using OpticaService.Models;

namespace OpticaService.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly MyDbContext _dbContext;

        public CategoriaRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetCategoriaById(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task PostCategoria(Categoria categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutCategoria(Categoria categoria)
        {
            _dbContext.Categorias.Update(categoria);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteCategoria(int id)
        {
            var categoriaToDelete = await _dbContext.Categorias.FindAsync(id);
            if (categoriaToDelete != null)
            {
                _dbContext.Categorias.Remove(categoriaToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
