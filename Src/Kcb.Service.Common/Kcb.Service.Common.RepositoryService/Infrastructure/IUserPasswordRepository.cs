using Kcb.Service.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryService.Infrastructure
{
    /// <summary>
    /// Init interface IUserPasswordRepository
    /// </summary>
    public interface IUserPasswordRepository
    {
        /// <summary>
        /// Get all UserPassword method
        /// </summary>
        /// <returns>list of userPasswords</returns>
        Task<IList<UserPassword>> Get();

        /// <summary>
        /// Get by id method
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>userPassword</returns>
        Task<UserPassword> Get(long id);

        /// <summary>
        /// Add a new user method
        /// </summary>
        /// <param name="userPassword">userPassword</param>
        void Add(UserPassword userPassword);

        /// <summary>
        /// Update a user method
        /// </summary>
        /// <param name="userPassword">userPassword</param>
        void Update(UserPassword userPassword);

        /// <summary>
        /// Delete a user method
        /// </summary>
        /// <param name="userPassword">userPassword</param>
        void Delete(UserPassword userPassword);

        /// <summary>
        /// Save method
        /// </summary>
        void Save();
    }
}
