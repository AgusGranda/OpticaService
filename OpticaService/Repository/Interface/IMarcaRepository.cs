using OpticaService.Models;

namespace OpticaService.Repository
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetAllMarcas();
        Task<Marca> GetMarcaById(int id);
        Task PostMarca(Marca marca);
        Task PutMarca(Marca marca);
        Task DeleteMarca(int id);
    }
}
