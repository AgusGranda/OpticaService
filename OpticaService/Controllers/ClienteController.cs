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
        public async Task<IActionResult> GetById(int id)
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
                return CreatedAtAction(nameof(GetById), new {id = cliente.Id }, cliente);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Cliente cliente, int id)
        {
            if (cliente != null)
            {
                var clienteToEdit = await _clienteRepository.GetClienteById(id);
                clienteToEdit.Telefono = cliente.Telefono;
                clienteToEdit.Apellido = cliente.Apellido;
                clienteToEdit.Nombre = cliente.Nombre;
                clienteToEdit.Mail = cliente.Mail;


                await _clienteRepository.UpdateCliente(cliente);
                return Ok(clienteToEdit);
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
                return Ok("Cliente Eliminado");

            }
            return NotFound();
        }


    }
}
