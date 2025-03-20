using Fictisia.Infraestructure.Models;
using System.ComponentModel.DataAnnotations;

namespace FictisiaSA.Pages.Personas.Models
{
    public class PersonaVM
    {
        public int PersonaId { get; set; }
        public int AdicionalesId { get; set; }
        public int ActivoId { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El Nombre solo puede contener letras")]
        public string Nombre { get; set; } = null!;

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El DNI solo puede contener números")]
        public int Dni { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "La EDAD solo puede contener números")]
        public int Edad { get; set; }
        public string Genero { get; set; } = null!;

        public EstadoVM Activo { get; set; } = null!;
        public AdicionalesVM Adicionales { get; set; } = null!;
    }
}
