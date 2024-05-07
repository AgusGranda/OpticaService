using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using OpticaService.Models;

namespace OpticaService.Repository
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicio>> GetAllServicio();
        Task<Servicio> GetServicioById(int id);
        Task PostServicio(Servicio servicio);
        Task PutServicio(Servicio servicio);
        Task DeleteServicio(int id);
    }
}
