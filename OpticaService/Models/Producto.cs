using System.ComponentModel;

namespace OpticaService.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal PrecioCompra { get; set; }
        public string Proveedor { get; set; }
        public string Codigo { get; set; }
        public Categoria Categoria{ get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public bool Estado { get; set; }
    }
}
