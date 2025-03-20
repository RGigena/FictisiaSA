using Fictisia.Application.Services;
using Fictisia.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Application
{
    /// <summary>
    /// Clase estática que proporciona métodos de extensión para la configuración de servicios de la capa de aplicación.
    /// </summary>
    /// 

    public static class ApplicationServiceRegistration
    {
        /// <summary>
        /// Agrega servicios de la capa de aplicación al contenedor de inyección de dependencias.
        /// </summary>
        /// <param name="services">La colección de servicios a la que se agregarán los servicios de la aplicación.</param>
        /// <returns>La colección de servicios después de agregar los servicios de la aplicación.</returns>
        /// 

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddTransient<IPersonaService, PersonaService>();

            return services
                .AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
