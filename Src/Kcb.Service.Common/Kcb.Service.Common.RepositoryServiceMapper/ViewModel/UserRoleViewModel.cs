using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryServiceMapper.ViewModel
{
    /// <summary>
    /// Init UserRoleViewModel
    /// </summary>
    public class UserRoleViewModel
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
        /// Gets or sets RoleId
        /// </summary>
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets ModifiedBy
        /// </summary>
        public long? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets ModifiedDate
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets Role
        /// </summary>
        public virtual RoleViewModel Role { get; set; }

        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual UserViewModel User { get; set; }
    }
}
