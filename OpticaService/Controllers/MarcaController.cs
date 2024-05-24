using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Repository;

namespace OpticaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : Controller
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _marcaRepository.GetAllMarcas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _marcaRepository.GetMarcaById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Marca marca)
        {
            if (marca != null)
            {
                await _marcaRepository.PostMarca(marca);
                return CreatedAtAction(nameof(GetById), new { id = marca.Id }, marca);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Marca marca)
        {
            var marcaToEdit = await _marcaRepository.GetMarcaById(id);
            if (marcaToEdit != null)
            {
                marcaToEdit.Descripcion = marca.Descripcion;
                await _marcaRepository.PutMarca(marcaToEdit);
                return Ok(marcaToEdit);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var marcaToDelete = await _marcaRepository.GetMarcaById(id);
            if(marcaToDelete != null)
            {
                await _marcaRepository.DeleteMarca(id);
                return Ok("Marca Eliminada");
            }
            return NotFound();
        }

    }
}
