using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Application.Dto
{
    public class PersonaDto
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Dni { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; } = null!;

        public EstadoDto Activo { get; set; } = null!;
        public AdicionalesDto Adicionales { get; set; } = null!;


    }
}
