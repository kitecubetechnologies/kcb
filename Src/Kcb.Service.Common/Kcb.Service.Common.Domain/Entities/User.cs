using System;
using System.Collections.Generic;
using System.Text;

namespace Kcb.Service.Common.Domain.Entities
{
    /// <summary>
    /// Init class User
    /// </summary>
    public partial class User : AuditEntity
    {
        /// <summary>
        /// Instance constructor user
        /// </summary>
        public User()
        {
            UserPassword = new HashSet<UserPassword>();
            UserRole = new HashSet<UserRole>();
        }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets MiddleName
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets PhoneNo
        /// </summary>
        public string PhoneNo { get; set; }

        /// <summary>
        /// Gets or sets IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets UserPassword
        /// </summary>
        public virtual ICollection<UserPassword> UserPassword { get; set; }

        /// <summary>
        /// Gets or sets UserRole
        /// </summary>
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
