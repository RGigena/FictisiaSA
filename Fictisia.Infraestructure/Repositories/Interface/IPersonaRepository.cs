using Fictisia.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Infraestructure.Repositories.Interface
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        Task<Persona?> ObtenerPorIdAsync(int PersonaId);
    }
}
