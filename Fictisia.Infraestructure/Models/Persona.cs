using System;
using System.Collections.Generic;

namespace Fictisia.Infraestructure.Models
{
    public partial class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Dni { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; } = null!;
        public int ActivoId { get; set; }
        public int AdicionalesId { get; set; }

        public virtual Estado Activo { get; set; } = null!;
        public virtual Adicionale Adicionales { get; set; } = null!;
    }
}
