﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Backend.DAL.Entities
{
    public class TelAcudiente
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        public long IdAcudiente { get; set; }

        [Key]
        [Column(Order = 1)]
        public long Telefono { get; set; }

        public ICollection<Acudiente> Acudiente { get; set; } //FK Referencia de Acudiente
    }
}
