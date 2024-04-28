using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Servicio
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string TipoServicio { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int CantServicio { get; set; }
        public string DescDiagnostico { get; set; } //Descripcion del diagnostico (HC)
        public string PrescDiagnostico { get; set; } //Prescripcion del diagnostico
        [Display(Name = "IdEmpleado")]
        public ICollection<Empleado> IdEmpleado { get; set; } //FK
        [Display(Name = "IdFactura")]
        public ICollection<Factura> IdFactura { get; set; } //FK
        public IEnumerable<Requiere> Requiere { get; set; }
    }
}
