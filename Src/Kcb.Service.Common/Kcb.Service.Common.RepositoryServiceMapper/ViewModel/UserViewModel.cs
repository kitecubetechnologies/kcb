using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryServiceMapper.ViewModel
{
    /// <summary>
    /// Init class UserViewModel
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Instance constructor user
        /// </summary>
        public UserViewModel()
        {
            UserPassword = new HashSet<UserPasswordViewModel>();
            UserRole = new HashSet<UserRoleViewModel>();
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
        /// Gets or sets UserPassword
        /// </summary>
        public virtual ICollection<UserPasswordViewModel> UserPassword { get; set; }

        /// <summary>
        /// Gets or sets UserRole
        /// </summary>
        public virtual ICollection<UserRoleViewModel> UserRole { get; set; }
    }
}
