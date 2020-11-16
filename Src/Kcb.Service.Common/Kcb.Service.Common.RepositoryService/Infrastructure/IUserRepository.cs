using Kcb.Service.Common.Domain.Entities;
using Kcb.Service.Common.Domain.RequestEntities.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryService.Infrastructure
{
    /// <summary>
    /// Init interface IUserRepository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Authenticate method
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns>model</returns>
        Task<User> Authenticate(string userName, string password);

        /// <summary>
        /// Get all users method
        /// </summary>
        /// <returns>list of users</returns>
        Task<IList<User>> Get();

        /// <summary>
        /// Get by id method
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>user</returns>
        Task<User> Get(long id);

        /// <summary>
        /// Add a new user method
        /// </summary>
        /// <param name="user">user</param>
        void Add(User user);

        /// <summary>
        /// Update a user method
        /// </summary>
        /// <param name="user">user</param>
        void Update(User user);

        /// <summary>
        /// Delete a user method
        /// </summary>
        /// <param name="user">user</param>
        void Delete(User user);

        /// <summary>
        /// Save method
        /// </summary>
        void Save();

        /// <summary>
        /// AddOrUpdateUsingProcedure method
        /// </summary>
        /// <param name="entity">entity</param>
        void AddOrUpdateUsingProcedure(UserRequestModel entity);
    }
}
