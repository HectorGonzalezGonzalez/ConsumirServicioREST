using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumirServicioREST
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Email { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Password { get; set; }
        public bool Estatus { get; set; }
        public DateTime Fecha_creo { get; set; }
        public string UsrCreoId { get; set; }
    }
}
