using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Application.Dto
{
    public class AdicionalesDto
    {
        public int AdicionalesId { get; set; }
        public bool Maneja { get; set; }
        public bool UsaLentes { get; set; }
        public bool EsDiabetico { get; set; }
        public bool OtraEnfermedad { get; set; }
        public string? Comentarios { get; set; }
    }
}
