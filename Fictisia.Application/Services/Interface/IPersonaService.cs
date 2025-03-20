using Fictisia.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Application.Services.Interface
{
    public interface IPersonaService
    {
        Task<List<PersonaDto?>> obtenerTodasLasPersonas();

        Task AgregarPersonaAsync(PersonaDto personaDto);

        Task<PersonaDto?> ObtenerPersonaPorId(int personaId);

        Task ActualizarPersonaAsync(PersonaDto personaDto);

        Task EliminarPersonaAsync(int persronaId);
    }
}
