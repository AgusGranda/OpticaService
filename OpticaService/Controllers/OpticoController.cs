using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Repository;

namespace OpticaService.Controllers
{
    [ApiController]
    [Route("{api/controller}")]
    public class OpticoController : Controller
    {

        private readonly IOpticoRepository _OpticoRepository;

        public OpticoController(IOpticoRepository opticoRepository)
        {
            _OpticoRepository = opticoRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var opticos = await _OpticoRepository.GetAllOpticos();
            return Ok(opticos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var optico = await _OpticoRepository.GetOpticoById(id);
            return Ok(optico);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Optico optico)
        {
            await _OpticoRepository.AddOptico(optico);
            return CreatedAtAction(nameof(Get), new {id = optico.Id }, optico);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Put(Optico optico, int id)
        {
            var opticoToEdit = await _OpticoRepository.GetOpticoById(id);
            if (opticoToEdit != null)
            {
                opticoToEdit.Celular = optico.Celular;
                opticoToEdit.HorarioLaboral = optico.HorarioLaboral;
                opticoToEdit.Nombre = optico.Nombre;
                opticoToEdit.Apellido = optico.Apellido;
                await _OpticoRepository.UpdateOptico(opticoToEdit);
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var opticoToDelete = await _OpticoRepository.GetOpticoById(id);
            if (opticoToDelete != null)
            {
                await _OpticoRepository.DeleteOptico(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
