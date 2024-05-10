using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Repository;

namespace OpticaService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : Controller
    {
       
        private readonly IModeloRepository _modeloRepository;

        public ModeloController(IModeloRepository modeloRepository)
        { 
            _modeloRepository = modeloRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _modeloRepository.GetAllModelos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _modeloRepository.GetModeloById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Modelo modelo)
        {
            if (modelo != null) 
            {
                await _modeloRepository.PostModelo(modelo);
                return CreatedAtAction(nameof(modelo), new { id = modelo.Id}, modelo);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Modelo modelo)
        {
            var modeloToEdit = await _modeloRepository.GetModeloById(id);
            if (modeloToEdit != null)
            {
                modeloToEdit.Descripcion = modelo.Descripcion;
                await _modeloRepository.PutModelo(modeloToEdit);
                return NoContent();
            }
            return NotFound();
        }



    }
}
