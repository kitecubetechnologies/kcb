using Kcb.Service.Common.Domain.Entities;
using Kcb.Service.Common.Domain.RequestEntities.RequestModel;
using Kcb.Service.Common.RepositoryPersistence.Data;
using Kcb.Service.Common.RepositoryPersistence.Infrastructure;
using Kcb.Service.Common.RepositoryService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryService.Repositories
{
    /// <summary>
    /// Init class UserRepository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// _context variable
        /// </summary>
        private readonly IGenericRepository<User> _repository;

        /// <summary>
        /// _authenticateRepository variable
        /// </summary>
        private readonly IAuthenticateRepository<User> _authenticateRepository;

        /// <summary>
        /// UserRepository constructor
        /// </summary>
        /// <param name="repository">repository</param>
        public UserRepository(IGenericRepository<User> repository, IAuthenticateRepository<User> authenticateRepository)
        {
            _repository = repository;
            _authenticateRepository = authenticateRepository;
        }

        /// <summary>
        /// Get by id method
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns>user</returns>
        public async Task<User> Authenticate(string userName, string password)
        {
            return await _authenticateRepository.Get(userName, password);
        }

        /// <summary>
        /// Get all users method
        /// </summary>
        /// <returns>list of users</returns>
        public async Task<IList<User>> Get()
        {
            return await _repository.Get();
        }

        /// <summary>
        /// Get by id method
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>user</returns>
        public async Task<User> Get(long id)
        {
            return await _repository.Get(id);
        }

        /// <summary>
        /// Add a new user method
        /// </summary>
        /// <param name="user">user</param>
        public void Add(User user)
        {
            _repository.Add(user);
        }

        /// <summary>
        /// Delete a user method
        /// </summary>
        /// <param name="user">user</param>
        public void Update(User user)
        {
            _repository.Update(user);
        }

        /// <summary>
        /// Update a user method
        /// </summary>
        /// <param name="user">user</param>
        public void Delete(User user)
        {
            _repository.Delete(user);
        }        

        /// <summary>
        /// Save method
        /// </summary>ss
        public void Save()
        {
            _repository.Save();
        }

        /// <summary>
        /// AddOrUpdateUsingProcedure method
        /// </summary>
        /// <param name="entity">entity</param>
        public void AddOrUpdateUsingProcedure(UserRequestModel entity)
        {
            _authenticateRepository.AddOrUpdateUsingProcedure(entity);
        }
    }
}
