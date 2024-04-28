using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Requiere
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long IdServicio { get; set; }
        public Servicio Servicio { get; set; }
        //public ICollection<Servicio> IdServicio { get; set; } //FK

        [Required]
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
    }
}
