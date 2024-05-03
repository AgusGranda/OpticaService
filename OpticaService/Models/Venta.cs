namespace OpticaService.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int Ficha { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Optico Optico { get; set; }
        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }
        public Servicio Servicio { get; set; }
        public int Descuento { get; set; }
        public decimal Precio { get; set; }
        public string Comentario { get; set; }
        public int Estado { get; set; }
    }
}
