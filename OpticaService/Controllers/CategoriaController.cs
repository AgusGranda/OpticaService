using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Repository;

namespace OpticaService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;


        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoriaRepository.GetAllCategorias());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoriaRepository.GetCategoriaById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Categoria categoria)
        {
            if (categoria != null)
            {
                await _categoriaRepository.PostCategoria(categoria);
                return CreatedAtAction(nameof(categoria), new { id = categoria.Id }, categoria);

            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Categoria categoria)
        {
            var categoriaToEdit = await _categoriaRepository.GetCategoriaById(id);

            if (categoria != null)
            {
                categoriaToEdit.Descripcion = categoria.Descripcion;
                await _categoriaRepository.PutCategoria(categoriaToEdit);
                return NoContent();
            }
            return NotFound();


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoriaToDelete = await _categoriaRepository.GetCategoriaById(id);
            if (categoriaToDelete != null)
            {
                await _categoriaRepository.DeleteCategoria(id);
                return NoContent();
            }
            return NotFound();
        }

    }
}
