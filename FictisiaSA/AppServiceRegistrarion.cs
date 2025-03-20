namespace FictisiaSA
{
    /// <summary>
    /// Clase estática responsable de registrar servicios de la app dentro del contenedor de inyección de dependencias de la aplicación.
    /// </summary>
    public static class AppServiceRegistrarion
    {
        /// <summary>
        /// Registra servicios de la app
        /// </summary>
        /// <param name="services">La <see cref="IServiceCollection"/> para agregar servicios.</param>
        /// <returns>La <see cref="IServiceCollection"/> modificada.</returns>
        /// 
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
