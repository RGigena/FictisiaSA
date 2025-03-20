using Fictisia.Infraestructure.Context;
using Fictisia.Infraestructure.Models;
using Fictisia.Infraestructure.Repositories;
using Fictisia.Infraestructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Infraestructure
{
    /// <summary>
    /// Clase estática responsable de registrar servicios de infraestructura dentro del contenedor de inyección de dependencias de la aplicación.
    /// </summary>
    public static class InfraestructureServiceRegistration
    {
        /// <summary>
        /// Registra servicios de infraestructura, como el contexto de la base de datos, dentro del contenedor de inyección de dependencias.
        /// </summary>
        /// <param name="services">La <see cref="IServiceCollection"/> para agregar servicios.</param>
        /// <param name="configuration">La <see cref="IConfiguration"/> que contiene las configuraciones.</param>
        /// <returns>La <see cref="IServiceCollection"/> modificada.</returns>
        /// 

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContextFactory<Clientes_FictisiaContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("Connection")));

            services.AddScoped<IRepository<Persona>, Repository<Persona, Clientes_FictisiaContext>>();

            services.AddScoped<IPersonaRepository, PersonaRepository>();

            return services;
        }
    }
}
