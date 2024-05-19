using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Paciente
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public char Sexo { get; set; }
        [Required]
        public float Peso { get; set; }
        [Required]
        public string Raza { get; set;}
        [Required]
        public string TipoAnimal { get; set;}
        //public ICollection<Servicio> Servicios { get; set; }

    }
}