using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryServiceMapper.ViewModel
{
    /// <summary>
    /// Init RoleViewModel
    /// </summary>
    public class RoleViewModel
    {
        /// <summary>
        /// Instance constructor RoleViewModel
        /// </summary>
        public RoleViewModel()
        {
            UserRole = new HashSet<UserRoleViewModel>();
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
        /// Gets or sets CreatedBy
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
        /// Gets or sets UserRole
        /// </summary>
        public virtual ICollection<UserRoleViewModel> UserRole { get; set; }
    }
}
