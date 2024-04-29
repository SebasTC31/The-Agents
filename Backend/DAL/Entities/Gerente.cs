using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DAL.Entities
{
    public class Gerente : Usuario
    {
        [Required] //FK
        [ForeignKey("Usuario")]
        public long IdUsuario { get; set; }
        public DateTime FechaContrato { get; set; }
        //       public ICollection<Usuario> Usuario { get; set; } //FK
        public Usuario Usuario { get; set; }    // Relación uno a uno (propiedad de navegación)
    }
}
