using OpticaService.Models;

namespace OpticaService.Repository
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProducts();
        Task<Producto> GetById(int id);
        Task AddProduct(Producto producto);
        Task PutProducto(Producto producto);
        Task DeleteProducto(int id);
    }
}
