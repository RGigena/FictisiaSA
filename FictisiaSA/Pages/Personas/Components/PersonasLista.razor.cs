using FictisiaSA.Pages.Personas.Models;
using Microsoft.AspNetCore.Components;

namespace FictisiaSA.Pages.Personas.Components
{
    public partial class PersonasLista
    {
        [Parameter]
        public List<PersonaVM> ListaPersonas { get; set; } = new List<PersonaVM>();
    }
}
