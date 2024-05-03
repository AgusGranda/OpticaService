namespace OpticaService.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string? Mail { get; set; }
        public  bool Estado { get; set; }
    }
}
