using System;
using System.Collections.Generic;
using System.Text;

namespace Kcb.Service.Common.Domain.Entities
{
    /// <summary>
    /// Init class Role
    /// </summary>
    public partial class Role : AuditEntity
    {
        /// <summary>
        /// Instance constructor Role
        /// </summary>
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        /// <summary>
        /// Gets or sets RoleId
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets RoleName
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets RoleDescription
        /// </summary>
        public string RoleDescription { get; set; }

        /// <summary>
        /// Gets or sets IsActive
        /// </summary>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Gets or sets UserRole
        /// </summary>
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}

