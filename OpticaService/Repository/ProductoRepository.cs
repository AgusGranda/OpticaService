using Microsoft.EntityFrameworkCore;
using OpticaService.DataAccess;
using OpticaService.Models;

namespace OpticaService.Repository
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly MyDbContext _dbContext;

        public ProductoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Producto>> GetAllProducts()
        {
            return await _dbContext.Productos.ToListAsync();
        }

        public async Task<Producto> GetProductById(int id)
        {
            return await _dbContext.Productos.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task AddProduct(Producto producto)
        {
            await _dbContext.Productos.AddAsync(producto);
            await _dbContext.SaveChangesAsync();
        }

       

        public async Task PutProducto(Producto producto)
        {
            _dbContext.Productos.Update(producto);
            await _dbContext.SaveChangesAsync();    
        }
        public async Task DeleteProducto(int id)
        {
           var productToDelete = await _dbContext.Productos.FirstOrDefaultAsync(x => x.Id == id);   
            if (productToDelete != null)
            {
                productToDelete.Estado = false;
                _dbContext.Productos.Update(productToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
