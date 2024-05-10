using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Repository;

namespace OpticaService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : Controller
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _servicioRepository.GetAllServicio());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _servicioRepository.GetServicioById(id));
        }


        [HttpPost]
        public async Task<IActionResult> Post(Servicio servicio)
        {
            if (servicio != null) 
            {
                await _servicioRepository.PostServicio(servicio);
                return CreatedAtAction(nameof(servicio), new { id = servicio.Id }, servicio);

            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Servicio servicio)
        {
            var servicioToEdit = await _servicioRepository.GetServicioById(id);
            if (servicioToEdit != null)
            {
                servicioToEdit.Descripcion = servicio.Descripcion;
                await _servicioRepository.PutServicio(servicioToEdit);
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servicioToDelete = await _servicioRepository.GetServicioById(id);
            if (servicioToDelete != null)
            {
                await _servicioRepository.DeleteServicio(id);
                return NoContent();
            }
            return NotFound();  
        }

    }
}
