﻿using System.Reflection.Metadata.Ecma335;

namespace OpticaService.Models
{
    public class Optico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public int Celular { get; set; }
        public int HorarioLaboral { get; set; }
    }
}
