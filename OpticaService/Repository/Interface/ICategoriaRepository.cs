using OpticaService.Models;

namespace OpticaService.Repository
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllCategorias();
        Task<Categoria> GetCategoriaById(int id);
        Task PostCategoria(Categoria categoria);
        Task PutCategoria(Categoria categoria);
        Task DeleteCategoria(int id);
    }
}
