using Kcb.Service.Common.Domain.Entities;
using Kcb.Service.Common.RepositoryPersistence.Data;
using Kcb.Service.Common.RepositoryPersistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryPersistence.Repositories
{
    /// <summary>
    /// Init class GenericRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        /// <summary>
        /// _context variable
        /// </summary>
        private readonly KcbApplicationDbContext _context;

        /// <summary>
        /// _entities variable
        /// </summary>
        private readonly DbSet<T> _entities;

        /// <summary>
        /// constructor GenericRepository
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="entities">entities</param>
        public GenericRepository(KcbApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        /// <summary>
        /// Get All method
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> Get()
        {
            try
            {
                return await _entities.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(_entities)} could not be retrieved: {ex.Message}");
            }
        }

        /// <summary>
        /// Get by Id method
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>T</returns>
        public async Task<T> Get(long id)
        {
            try
            {
                return await _entities.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be retrieved: {ex.Message}");
            }
        }
                
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            try
            {
                _entities.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be added: {ex.Message}");
            }
        }

       
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

                try
                {
                    _entities.Update(entity);
                }
                catch (Exception ex)
                {
                    throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
                }
            }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            try
            {
                _entities.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(_context)} could not be updated: {ex.Message}");
            }
        }
    }
}
