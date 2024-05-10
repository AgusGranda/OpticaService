using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Repository;

namespace OpticaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OpticoController : Controller
    {
        private readonly IOpticoRepository _opticoRepository;

        public OpticoController(IOpticoRepository opticoRepository)
        {
            _opticoRepository = opticoRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _opticoRepository.GetAllOpticos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _opticoRepository.GetOpticoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Optico optico)
        {
            if(optico != null) 
            { 
                await _opticoRepository.AddOptico(optico);
                return CreatedAtAction(nameof(optico), new { id = optico.Id}, optico);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Optico optico)
        {
            var opticoToEdit = await _opticoRepository.GetOpticoById(id);
            if(opticoToEdit != null)
            {
                opticoToEdit.Nombre = optico.Nombre;
                opticoToEdit.Apellido = optico.Apellido;
                await _opticoRepository.UpdateOptico(opticoToEdit);
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var opticoToDelete = _opticoRepository.GetOpticoById(id);
            if(opticoToDelete != null)
            {
                await _opticoRepository.DeleteOptico(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
