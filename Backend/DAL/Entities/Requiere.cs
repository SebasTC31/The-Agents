using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Requiere
    {
        [Required]
        public long IdServicio { get; set; }
        public Servicio Servicio { get; set; }

        [Required]
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
    }
}
