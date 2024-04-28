using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DAL.Entities
{
    public class Factura
    {
        [Key]
        [Column(Order = 0)]
        public long Id { get; set; }
        [Key]
        [Column(Order = 1)] // Orden del segundo campo en la clave primaria compuesta
        public long IdServicio { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public float ValorTotal { get; set; }
        [Required]
        public string MetodoPago { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Estado { get; set; }
        [Display(Name = "IdAcudiente")]
        public ICollection<Acudiente> IdAcudiente { get; set; } //FK
    }
}
