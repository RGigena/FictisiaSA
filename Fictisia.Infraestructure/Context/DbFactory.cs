using Microsoft.EntityFrameworkCore;
using GoleAdmin.Infraestructure.Context;
using Fictisia.Infraestructure.Context;


namespace GoleAdmin.Infraestructure.Context
{
    /// <summary>
    /// Clase que implementa un patrón de fábrica para gestionar instancias de DbContext en una aplicación.
    /// </summary>
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private readonly IDbContextFactory<Clientes_FictisiaContext> dbContextFactory;
        private readonly DbContext? _dbContext;

        /// <summary>
        /// Obtiene la instancia actual de DbContext. Si no existe, se crea utilizando la función de fábrica.
        /// </summary>
        public DbContext DbContext => dbContextFactory.CreateDbContext();

        /// <summary>
        /// Inicializa una nueva instancia de la clase DbFactory.
        /// </summary>
        /// <param name="dbContextFactory">Función de fábrica que crea instancias de DbContext.</param>
        public DbFactory(IDbContextFactory<Clientes_FictisiaContext> dbContextFactory, DbContext dbContext)
        {
            this.dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
            _dbContext = dbContext;
        }

        /// <summary>
        /// Libera los recursos utilizados por la instancia de la clase DbFactory.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Libera los recursos no administrados utilizados por la instancia de la clase DbFactory.
        /// </summary>
        /// <param name="disposing">Indica si se están liberando recursos administrados.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
