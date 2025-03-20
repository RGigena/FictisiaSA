using AutoMapper;
using Fictisia.Application.Dto;
using Fictisia.Application.Services.Interface;
using FictisiaSA.Pages.Personas.Models;
using Microsoft.AspNetCore.Components;

namespace FictisiaSA.Pages.Personas.Components
{
    public partial class AgregarPersona
    {
        [Inject]
        public IMapper mapper { get; set; } = null!;

        [Inject]
        public IPersonaService personaService { get; set; } = null!;

        [Inject]
        public NavigationManager navigationManager { get; set; } = null!;

        public PersonaVM PersonaVM { get; set; } = new PersonaVM
        {
            Activo = new EstadoVM(),
            Adicionales = new AdicionalesVM()
        };

        public async Task AgregarPersonas()
        {
            var personaDto = mapper.Map<PersonaDto>(PersonaVM);
            await personaService.AgregarPersonaAsync(personaDto);
            navigationManager.NavigateTo("./persona", forceLoad: true);
        }
    }
}
