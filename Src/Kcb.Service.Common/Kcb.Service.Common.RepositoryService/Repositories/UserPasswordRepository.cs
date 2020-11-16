using Kcb.Service.Common.Domain.Entities;
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
    /// Init class UserPasswordRepository
    /// </summary>
    public class UserPasswordRepository : IUserPasswordRepository
    {
        /// <summary>
        /// _context variable
        /// </summary>
        private readonly IGenericRepository<UserPassword> _repository;

        /// <summary>
        /// UserRepository constructor
        /// </summary>
        /// <param name="repository">repository</param>
        public UserPasswordRepository(IGenericRepository<UserPassword> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all users method
        /// </summary>
        /// <returns>list of users</returns>
        public async Task<IList<UserPassword>> Get()
        {
            return await _repository.Get();
        }

        /// <summary>
        /// Get by id method
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>userPassword</returns>
        public async Task<UserPassword> Get(long id)
        {
            return await _repository.Get(id);
        }

        /// <summary>
        /// Add a new user method
        /// </summary>
        /// <param name="userPassword">userPassword</param>
        public void Add(UserPassword userPassword)
        {
            _repository.Add(userPassword);
        }

        /// <summary>
        /// Delete a user method
        /// </summary>
        /// <param name="userPassword">userPassword</param>
        public void Update(UserPassword userPassword)
        {
            _repository.Update(userPassword);
        }

        /// <summary>
        /// Update a userPassword method
        /// </summary>
        /// <param name="userPassword">userPassword</param>
        public void Delete(UserPassword userPassword)
        {
            _repository.Delete(userPassword);
        }

        /// <summary>
        /// Save method
        /// </summary>ss
        public void Save()
        {
            _repository.Save();
        }
    }
}
