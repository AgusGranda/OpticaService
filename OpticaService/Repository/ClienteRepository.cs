using Microsoft.EntityFrameworkCore;
using OpticaService.DataAccess;
using OpticaService.Models;

namespace OpticaService.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly MyDbContext _dbContext;

        public ClienteRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {

            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> GetClienteByPhone(int telefono)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Telefono == telefono);

        }


        public async Task AddCliente(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateCliente(Cliente cliente)
        {
            _dbContext.Clientes.Update(cliente);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteCliente(int id)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (cliente != null)
            {
                cliente.Estado = false;
                _dbContext.Clientes.Update(cliente);
                await _dbContext.SaveChangesAsync();
            }
        }

       
    }
}
