
using Microsoft.AspNetCore.Mvc;
using OpticaService.Models;
using OpticaService.Repository;

namespace OpticaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productoRepository.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productoRepository.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            if (producto != null) 
            {
                await _productoRepository.AddProduct(producto);
                return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto producto)
        {
            var productoToEdit = await _productoRepository.GetProductById(id);
            if (productoToEdit != null)
            {
                productoToEdit.Proveedor = producto.Proveedor;
                productoToEdit.FechaCompra = producto.FechaCompra;
                productoToEdit.Codigo = producto.Codigo;
                productoToEdit.PrecioCompra = producto.PrecioCompra;
                productoToEdit.Marca = producto.Marca;
                productoToEdit.Categoria = producto.Categoria;
                productoToEdit.Modelo = producto.Modelo;

                await _productoRepository.PutProducto(productoToEdit);
                return Ok(productoToEdit);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productoToDelete = await _productoRepository.GetProductById(id);
            if (productoToDelete != null)
            {
                await _productoRepository.DeleteProducto(id);
                return Ok("Producto Eliminado");
            }
            return NotFound();
        }
    }
}
