using Fictisia.Infraestructure.Models;
using Fictisia.Infraestructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fictisia.Infraestructure.Repositories
{
    /// <summary>
    /// Implementacion generica de la interfaz IRepository<TEntity>.
    /// Proporciona operaciones basicas para el manejo de entidades en una base de datos.
    /// </summary>
    /// <typeparam name="TEntity">Tipo de entidad que manejara el repositorio.</typeparam>
    /// 
    public class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : class, new() where TDbContext : DbContext
    {
        private readonly IDbContextFactory<TDbContext> _dbContextFactory;

        protected DbContext _DbContext
        {
            get
            {
                return _dbContextFactory.CreateDbContext();
            }
        }

        public Repository(IDbContextFactory<TDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Add(TEntity entity)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Set<TEntity>().Add(entity);
                dbContext.SaveChanges();
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            try
            {
                using (var dbContext = _dbContextFactory.CreateDbContext())
                {
                    await dbContext.Set<TEntity>().AddAsync(entity);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(TEntity entity)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Set<TEntity>().Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public async Task DeleteAsync(int personaId)
        {
            using (var dbContext = _DbContext)
            {
                var persona = await dbContext.Set<Persona>().FirstOrDefaultAsync(p => p.PersonaId == personaId);

                dbContext.Set<Persona>().Remove(persona);
                await dbContext.SaveChangesAsync();
            }
        }

        public void Update(TEntity entity)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Set<TEntity>().Update(entity);
                dbContext.SaveChanges();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Set<TEntity>().Update(entity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>?> ObtenerTodosAsync()
        {
            try
            {
                using (var dbContext = _dbContextFactory.CreateDbContext())
                {
                    return await dbContext.Set<TEntity>().ToListAsync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Persona>> ObtenerTodos()
        {
            try
            {
               using (var dbContext = _DbContext)
               {
                    return await dbContext.Set<Persona>()
                        .Include(x => x.Activo)
                        .Include(a => a.Adicionales).ToListAsync();
               }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return await dbContext.Set<TEntity>().Where(expression).ToListAsync();
            }
        }
    }
}
