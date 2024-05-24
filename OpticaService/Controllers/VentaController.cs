using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Repository;

namespace OpticaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaController(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ventaRepository.GetAllVentas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _ventaRepository.GetVentaById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Venta venta)
        {
            if (venta != null)
            {
                await _ventaRepository.PostVenta(venta);
                return CreatedAtAction(nameof(GetById), new { id = venta.Id }, venta);

            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id , Venta venta)
        {
            var ventaToEdit = await _ventaRepository.GetVentaById(id);
            if (venta != null)
            {
                ventaToEdit.Ficha = venta.Ficha;
                ventaToEdit.FechaVenta = venta.FechaVenta;
                ventaToEdit.FechaEntrega = venta.FechaEntrega;
                ventaToEdit.Optico = venta.Optico;
                ventaToEdit.Cliente = venta.Cliente;
                ventaToEdit.Producto = venta.Producto;
                ventaToEdit.Servicio = venta.Servicio;
                ventaToEdit.Descuento = venta.Descuento;
                ventaToEdit.Precio = venta.Precio;
                ventaToEdit.Comentario = venta.Comentario;
                await _ventaRepository.PutVenta(ventaToEdit);
                return Ok(ventaToEdit);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var ventaToDelete = await _ventaRepository.GetVentaById(id);
            if (ventaToDelete != null)
            {
                await _ventaRepository.DeleteVenta(id);
                return Ok("Venta eliminada");
            }
            return NotFound();
        }

    }
}
