using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Gerente //: Usuario
    {
        //[Required] //FK
        //public long IdUsuario { get; set; }
        [Key]
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaContrato { get; set; }
        public string ObtenerFechaFormato()
        {
            return FechaContrato.ToString("yyyy-MM-dd");
        }
        //public ICollection<Usuario> Usuario { get; set; } //FK
        //public Usuario Usuario { get; set; } //FK Relación 1 a 1 (propiedad de navegación)

    }
}
