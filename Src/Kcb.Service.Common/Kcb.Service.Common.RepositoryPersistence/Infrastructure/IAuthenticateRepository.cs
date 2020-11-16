using Kcb.Service.Common.Domain.Entities;
using Kcb.Service.Common.Domain.RequestEntities.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryPersistence.Infrastructure
{
    /// <summary>
    /// Init interface IAuthenticateRepository
    /// </summary>
    public interface IAuthenticateRepository<T> where T : class, new()
    {
        /// <summary>
        /// Get by userName and password method
        /// </summary>
        /// <param name="userName">userName</param>
        /// /// <param name="password">password</param>
        /// <returns>T</returns>
        Task<T> Get(string userName, string password);

        /// <summary>
        /// AddOrUpdateUsingProcedure method
        /// </summary>
        /// <param name="entity">entity</param>
        void AddOrUpdateUsingProcedure(UserRequestModel entity);
    }
}
