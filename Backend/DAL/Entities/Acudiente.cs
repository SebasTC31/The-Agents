using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Acudiente
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public char Sexo { get; set; }
        [Required]
        public int Edad { get; set; }
        [Display(Name = "IdPaciente")]
        public ICollection<Paciente> IdPaciente { get; set; } //FK
        public IEnumerable<TelAcudiente> TelAcudiente { get; set; }//Para el atributo multivalorado
    }
}