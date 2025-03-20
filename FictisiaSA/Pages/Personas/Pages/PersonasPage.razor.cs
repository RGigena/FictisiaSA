using AutoMapper;
using Fictisia.Application.Services.Interface;
using FictisiaSA.Pages.Personas.Models;
using Microsoft.AspNetCore.Components;

namespace FictisiaSA.Pages.Personas.Pages
{
    public partial class PersonasPage
    {
        public List<PersonaVM> ListaPersonaModel { get; set; } = new List<PersonaVM>();

        [Inject]
        private IMapper Mapper { get; set; } = null!;

        [Inject]
        private IPersonaService PersonaService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var totalPersonas = await PersonaService.obtenerTodasLasPersonas();
                ListaPersonaModel = Mapper.Map<List<PersonaVM>>(totalPersonas);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
