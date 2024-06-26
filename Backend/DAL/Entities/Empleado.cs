﻿using System.ComponentModel.DataAnnotations;

namespace Backend.DAL.Entities
{
    public class Empleado //: Usuario
    {
        //[Required] //FK
        //public long IdUsuario { get; set; }
        [Key]
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public float Sueldo { get; set; }
        public string TipoEmpleado { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public ICollection<Servicio> Servicio { get; set; } //FK // Relación con Servicios
        //public ICollection<Usuario> Usuario { get; set; } //FK
        //public Usuario Usuario { get; set; } //FK Relación 1 a 1 (propiedad de navegación)
    }
}
