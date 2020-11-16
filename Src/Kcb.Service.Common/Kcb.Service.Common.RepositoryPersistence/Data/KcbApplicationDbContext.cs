using Kcb.Service.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kcb.Service.Common.RepositoryPersistence.Data
{
    /// <summary>
    /// Init class KcbApplicationDbContext
    /// </summary>
    public partial class KcbApplicationDbContext : DbContext
    {
        /// <summary>
        /// Parameterized instance constructor KcbApplicationDbContext
        /// </summary>
        /// <param name="options"></param>
        public KcbApplicationDbContext(DbContextOptions<KcbApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets Role
        /// </summary>
        public virtual DbSet<Role> Role { get; set; }

        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual DbSet<User> User { get; set; }

        /// <summary>
        /// Gets or sets UserPassword
        /// </summary>
        public virtual DbSet<UserPassword> UserPassword { get; set; }

        /// <summary>
        ///  Gets or sets UserRole
        /// </summary>
        public virtual DbSet<UserRole> UserRole { get; set; }        
    }
}

