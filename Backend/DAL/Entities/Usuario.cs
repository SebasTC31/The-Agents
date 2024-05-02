using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DAL.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Esto indica que no es una columna de identidad
        public long Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public long Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string User { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        public char Sexo { get; set; }
        [Required]
        public int Edad { get; set; }
        //public ICollection<Gerente> Gerentes { get; set; } //FK Relación 1 a muchos
        //public ICollection<Empleado> Empleados { get; set; } //FK Relación 1 a muchos
    }
}
