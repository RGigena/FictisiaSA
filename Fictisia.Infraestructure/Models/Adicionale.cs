using System;
using System.Collections.Generic;

namespace Fictisia.Infraestructure.Models
{
    public partial class Adicionale
    {
        public Adicionale()
        {
            Personas = new HashSet<Persona>();
        }

        public int AdicionalesId { get; set; }
        public bool Maneja { get; set; }
        public bool UsaLentes { get; set; }
        public bool EsDiabetico { get; set; }
        public bool OtraEnfermedad { get; set; }
        public string? Comentarios { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
