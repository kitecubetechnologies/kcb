using System;
using System.Collections.Generic;
using System.Text;

namespace Kcb.Service.Common.Domain.Entities
{
    /// <summary>
    /// Init class UserRole
    /// </summary>
    public partial class UserRole : AuditEntity
    {
        /// <summary>
        /// Gets or sets RoleId
        /// </summary>
        public long UserRoleId { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets RoleId
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets Role
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
    }
}