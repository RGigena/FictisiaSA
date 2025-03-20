using Fictisia.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Infraestructure.Repositories.Interface
{
    /// <summary>
    /// Interfaz generica que define operaciones basicas para un repositorio de entidades.
    /// </summary>
    /// <typeparam name="TEntity">Tipo de entidad que manejara el repositorio.</typeparam>
    /// 

    public interface IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Agrega una nueva entidad al repositorio.
        /// </summary>
        void Add(TEntity entity);

        /// <summary>
        /// Agrega asincronicamente una nueva entidad al repositorio.
        /// </summary>
        /// <param name="entity">Tipo de entidad que maneja el repositorio</param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Elimina una entidad del repositorio.
        /// </summary>
        /// <param name="entity">Tipo de entidad que maneja el repositorio</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Actualiza una entidad en el repositorio.
        /// </summary>
        /// <param name="entity">Tipo de entidad que maneja el repositorio</param>
        void Update(TEntity entity);

        /// <summary>
        /// Actualiza una entidad en el repositorio, de forma asincronica
        /// </summary>
        /// <param name="entity">Tipo de entidad que maneja el repositorio</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Obtiene todas las personas, de forma asincronica
        /// </summary>
        /// <param name="entity">Tipo de entidad que maneja el repositorio</param>
        Task<List<TEntity>?> ObtenerTodosAsync();

        Task DeleteAsync(int personaId);

        Task<List<Persona>> ObtenerTodos();
    }
}
