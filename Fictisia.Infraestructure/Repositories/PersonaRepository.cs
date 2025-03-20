using Fictisia.Infraestructure.Context;
using Fictisia.Infraestructure.Models;
using Fictisia.Infraestructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Infraestructure.Repositories
{
    public class PersonaRepository : Repository<Persona, Clientes_FictisiaContext>, IPersonaRepository
    {
        public PersonaRepository(IDbContextFactory<Clientes_FictisiaContext> dbFactory) : base(dbFactory)
        {}

        public async Task<Persona?> ObtenerPorIdAsync(int PersonaId)
        {
            using (var dbContext = _DbContext)
            {
                return await dbContext.Set<Persona>()
                    .Include(e => e.Activo)
                    .Include(a => a.Adicionales)
                    .Where(p => p.PersonaId == PersonaId)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
