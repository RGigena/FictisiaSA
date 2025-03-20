using AutoMapper;
using Fictisia.Application.Dto;
using Fictisia.Application.Services.Interface;
using Fictisia.Infraestructure.Models;
using FictisiaSA.Pages.Personas.Models;
using Microsoft.AspNetCore.Components;

namespace FictisiaSA.Pages.Personas.Components
{
    public partial class EditarPersona
    {
        [Inject]
        public IMapper mapper { get; set; } = null!;
        [Inject]
        public IPersonaService personaService { get; set; } = null!;
        [Inject]
        public NavigationManager navigationManager { get; set; } = null!;

        [Parameter]
        public int personaId { get; set; }

        public PersonaVM PersonaVM { get; set; } = new PersonaVM
        {
            Activo = new EstadoVM(),
            Adicionales = new AdicionalesVM()
        };

        protected override async Task OnInitializedAsync()
        {
            var personaDto = await personaService.ObtenerPersonaPorId(personaId);
            PersonaVM = mapper.Map<PersonaVM>(personaDto);
        }

        private async Task GuardarCambios()
        {
            var personaDto = mapper.Map<PersonaDto>(PersonaVM);
            await personaService.ActualizarPersonaAsync(personaDto);
            navigationManager.NavigateTo("/");
        }
    }
}
