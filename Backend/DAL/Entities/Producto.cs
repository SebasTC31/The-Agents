using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Producto
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public int CantUso { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public IEnumerable<Requiere> Requiere { get; set; }

    }
}
