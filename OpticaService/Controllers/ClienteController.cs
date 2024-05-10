using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Repository;

namespace OpticaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clienteRepository.GetAllClientes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _clienteRepository.GetClienteById(id));
        }

        [HttpGet("{telefono}")]
        public async Task<IActionResult> GetByPhone(int telefono)
        {
            return Ok(await _clienteRepository.GetClienteByPhone(telefono));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            if (cliente != null)
            {
                await _clienteRepository.AddCliente(cliente);
                return CreatedAtAction(nameof(cliente), new {id = cliente.Id }, cliente);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Cliente cliente, int id)
        {
            if (cliente != null)
            {
                var clienteToEdito = await _clienteRepository.GetClienteById(id);
                clienteToEdito.Telefono = cliente.Telefono;
                clienteToEdito.Apellido = cliente.Apellido;
                clienteToEdito.Nombre = cliente.Nombre;
                clienteToEdito.Mail = cliente.Mail;


                await _clienteRepository.UpdateCliente(cliente);
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete( int id)
        {
            var clienteTodelete = await _clienteRepository.GetClienteById(id);
            if (clienteTodelete != null)
            {
                await _clienteRepository.DeleteCliente(id);
                return NoContent();

            }
            return NotFound();
        }


    }
}
