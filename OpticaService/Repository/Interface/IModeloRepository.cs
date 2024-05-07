using OpticaService.Models;

namespace OpticaService.Repository
{
    public interface IModeloRepository
    {
        Task<IEnumerable<Modelo>> GetAllModelos();
        Task<Modelo> GetModeloById(int id);
        Task PostModelo(Modelo modelo);
        Task PutModelo(Modelo modelo);
        Task DeleteModelo(int id);
    }
}
