using System;
using System.Collections.Generic;

namespace Fictisia.Infraestructure.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Personas = new HashSet<Persona>();
        }

        public int ActivoId { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
