using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Backend.DAL.Entities
{
    public class TelAcudiente
    {
        //[Key]         Aquí estoy omitiendo la acción de PK, puesto que estoy deifniendo la llave compuesta en el modelBuilder
        [Required]
        [Column(Order = 0)]
        public long IdAcudiente { get; set; }

        //[Key]         Igualmente aquí se aplica la misma lógica
        [Column(Order = 1)]
        public long Telefono { get; set; }

        public Acudiente Acudiente { get; set; } //FK Referencia de Acudiente
        //public ICollection<Acudiente> Acudiente { get; set; } //FK Referencia de Acudiente
    }
}
