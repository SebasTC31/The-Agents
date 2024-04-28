using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DAL.Entities
{
    public class Empleado : Usuario
    {
        [Required] //FK
        [ForeignKey("Usuario")]
        public long IdUsuario { get; set; }
        public float Sueldo { get; set; }
        public string TipoEmpleado { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public Usuario Usuario { get; set; }    // Relación uno a uno (propiedad de navegación)
    }
}
