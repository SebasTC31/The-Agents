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
        public long ServicioId { get; set; }
        [ForeignKey(nameof(ServicioId))]
        public Servicio Servicio { get; set; }          //public ICollection<Servicio> IdServicio { get; set; } //FK
        [Required]
        public long ProductoId { get; set; } 
        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }
    }
}
