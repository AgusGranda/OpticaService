using OpticaService.Models;

namespace OpticaService.Repository
{
    public interface IOpticoRepository
    {
        Task<IEnumerable<Optico>> GetAllOpticos();
        Task<Optico> GetOpticoById(int id);
        Task AddOptico(Optico optico);
        Task UpdateOptico(Optico optico);
        Task DeleteOptico(int id);
        Task<Optico> Login(string nombre, string contraseña);
    }
}
