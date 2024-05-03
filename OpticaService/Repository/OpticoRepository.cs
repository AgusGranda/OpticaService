using Microsoft.EntityFrameworkCore;
using OpticaService.DataAccess;
using OpticaService.Models;

namespace OpticaService.Repository
{
    public class OpticoRepository : IOpticoRepository
    {

        private readonly MyDbContext _dbContext;

        public OpticoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Optico>> GetAllOpticos()
        {
            return await _dbContext.Opticos.ToListAsync();
        }

        public async Task<Optico> GetOpticoById(int id)
        {
            return await _dbContext.Opticos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddOptico(Optico optico)
        {
            await _dbContext.Opticos.AddAsync(optico);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateOptico(Optico optico)
        {
            _dbContext.Update(optico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOptico(int id)
        {
            // eliminacion loginca de optico

            var opticoToDelete = await _dbContext.Opticos.FirstOrDefaultAsync(x => x.Id == id); 
            if (opticoToDelete != null)
            {
                opticoToDelete.Estado = false;
                _dbContext.Opticos.Update(opticoToDelete);
                _dbContext.SaveChanges();
            }
        }

        
        public async Task<Optico> Login(string nombre, string contraseña)
        {
            var optico = await _dbContext.Opticos.FirstOrDefaultAsync(x => x.Nombre == nombre && x.Contraseña == contraseña);
            return optico;
        }

       
    }
}
