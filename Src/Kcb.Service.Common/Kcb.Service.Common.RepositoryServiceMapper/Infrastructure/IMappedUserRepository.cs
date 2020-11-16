using Kcb.Service.Common.Domain.RequestEntities.RequestModel;
using Kcb.Service.Common.RepositoryServiceMapper.ViewModel;
using Kcb.Service.Common.RepositoryServiceMapper.ViewModel.Authenticate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryServiceMapper.Infrastructure
{
    /// <summary>
    /// Init interface IMappedUserRepository
    /// </summary>
    public interface IMappedUserRepository
    {
        /// <summary>
        /// Authenticate method
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>AuthenticateResponseViewModel</returns>
        Task<AuthenticateResponseViewModel> Authenticate(AuthenticateRequestViewModel model);

        /// <summary>
        /// Get all users method
        /// </summary>
        /// <returns>list of users</returns>
        Task<IList<UserViewModel>> Get();

        /// <summary>
        /// Get by id method
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>user</returns>
        Task<UserViewModel> Get(long id);

        /// <summary>
        /// Add a new user method
        /// </summary>
        /// <param name="user">user</param>
        void Add(UserViewModel user);

        /// <summary>
        /// Update a user method
        /// </summary>
        /// <param name="user">user</param>
        void Update(UserViewModel user);

        /// <summary>
        /// Delete a user method
        /// </summary>
        /// <param name="user">user</param>
        void Delete(UserViewModel user);

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
