using Fictisia.Application.Services.Interface;
using FictisiaSA.Pages.Personas.Models;
using Microsoft.AspNetCore.Components;

namespace FictisiaSA.Pages.Personas.Components
{
    public partial class PersonasItem
    {
        [Parameter]
        public PersonaVM PersonaVM { get; set; } = null!;

        [Inject]
        public NavigationManager navigationManager { get; set; } = null!;

        [Inject]
        public IPersonaService personaService { get; set; } = null!;

        private PersonaVM personaParaEliminar = null!;

        private bool showConfirmationModal = false;
        private bool showConfirmationDeleteModal = false;

        private void VerMas(int idContenido)
        {
            showConfirmationModal = true;
        }

        public void EditarCliente(int personaId)
        {
            var editarPersonaUrl = $"./editarCliente/{personaId}";

            navigationManager.NavigateTo(editarPersonaUrl, forceLoad: true);
        }

        private void EliminarCliente(int personaId)
        {
            personaParaEliminar = PersonaVM;
            showConfirmationDeleteModal = true;

        }

        public async Task ConfirmarEliminarCliente()
        {
            await personaService.EliminarPersonaAsync(personaParaEliminar.PersonaId);
            showConfirmationDeleteModal = false;
            navigationManager.NavigateTo("./persona", forceLoad: true);
        }

        private void CloseModal()
        {
            showConfirmationModal = false;
        }

        private void CloseModalEliminar()
        {
            showConfirmationDeleteModal = false;
        }
    }
}
