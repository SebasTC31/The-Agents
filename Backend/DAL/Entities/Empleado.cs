using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Empleado : Usuario
    {
        [Required] //FK
        public long IdUsuario { get; set; }
        public float Sueldo { get; set; }
        public string TipoEmpleado { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public ICollection<Usuario> Usuario { get; set; } //FK
    }
}
