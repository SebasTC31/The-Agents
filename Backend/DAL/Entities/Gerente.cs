using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Gerente : Usuario
    {
        [Required] //FK
        public long IdUsuario { get; set; }
        public DateTime FechaContrato { get; set; }
        public ICollection<Usuario> Usuario { get; set; } //FK

    }
}
