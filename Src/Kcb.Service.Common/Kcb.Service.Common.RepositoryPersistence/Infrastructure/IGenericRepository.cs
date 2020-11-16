using Kcb.Service.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryPersistence.Infrastructure
{
    /// <summary>
    /// Init interface IGenericRepository
    /// </summary>
    public interface IGenericRepository<T> where T: class, new()
    {
        /// <summary>
        /// Get by Id method
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>T</returns>
        Task<T> Get(long id);

        /// <summary>
        /// GetAll method
        /// </summary>
        /// <returns>T</returns>
        Task<IList<T>> Get();

        /// <summary>
        /// Add method
        /// </summary>
        /// <param name="entity">entity</param>
        void Add(T entity);

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="entity">entity</param>
        void Delete(T entity);

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="entity">entity</param>
        void Update(T entity);

        /// <summary>
        /// Save method
        /// </summary>
        void Save();
    }
}
