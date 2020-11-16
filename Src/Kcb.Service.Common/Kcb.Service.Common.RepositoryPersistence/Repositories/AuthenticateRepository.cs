using Kcb.Service.Common.Domain.Entities;
using Kcb.Service.Common.Domain.RequestEntities.RequestModel;
using Kcb.Service.Common.RepositoryPersistence.Data;
using Kcb.Service.Common.RepositoryPersistence.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryPersistence.Repositories
{
    /// <summary>
    /// Init class AuthenticateRepository
    /// </summary>
    public class AuthenticateRepository<T> : IAuthenticateRepository<T> where T : class, new()
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
        /// constructor AuthenticateRepository
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="entities">entities</param>
        public AuthenticateRepository(KcbApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        /// <summary>
        /// Get by username password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<T> Get(string userName, string password)
        {
            IList<T> result = await _entities.FromSqlRaw($"EXECUTE GetUserValidation @userName, @password",
                new SqlParameter("userName", userName),
                new SqlParameter("password", password))
                .IgnoreQueryFilters()
                .ToListAsync();

            return result.FirstOrDefault();
        }

        /// <summary>
        /// AddOrUpdateUsingProcedure method
        /// </summary>
        /// <param name="entity">entity</param>
        public void AddOrUpdateUsingProcedure(UserRequestModel entity)
        {
            if (entity.LoggedInUserId == 0)
            {
                entity.LoggedInUserId = -1;
            }

            _context.Database.ExecuteSqlInterpolated($"EXECUTE [dbo].[InsertOrUpdateUserwithPassword] @userId = { entity.UserId }, @firstName = { entity.FirstName }, @middleName = {entity.MiddleName}, @lastName = {entity.LastName}, @userName = {entity.UserName}, @emailAddress = {entity.EmailAddress}, @phoneNo = {entity.PhoneNo}, @isActive = {entity.IsActive}, @password = { entity.UserPassword }, @loginUserId = { entity.LoggedInUserId} ");
        }
    }
}
