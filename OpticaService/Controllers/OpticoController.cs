using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Models.DTO;
using OpticaService.Repository;

namespace OpticaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OpticoController : Controller
    {
        private readonly IOpticoRepository _opticoRepository;
        public readonly IMapper _mapper;

        public OpticoController(IOpticoRepository opticoRepository, IMapper mapper)
        {
            _opticoRepository = opticoRepository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var opticos = await _opticoRepository.GetAllOpticos();
            var auxOpticoDTO = _mapper.Map<List<OpticoDTO>>(opticos);

            return Ok(auxOpticoDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _opticoRepository.GetOpticoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Optico optico)
        {
            if(optico != null) 
            { 
                await _opticoRepository.AddOptico(optico);
                return CreatedAtAction(nameof(GetById), new { id = optico.Id}, optico);
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
                return Ok();
            }
            return NotFound(opticoToEdit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var opticoToDelete = _opticoRepository.GetOpticoById(id);
            if(opticoToDelete != null)
            {
                await _opticoRepository.DeleteOptico(id);
                return Ok("Optico Eliminado");
            }
            return NotFound();
        }
    }
}
