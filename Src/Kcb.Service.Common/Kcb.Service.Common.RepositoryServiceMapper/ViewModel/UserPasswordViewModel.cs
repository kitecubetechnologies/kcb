using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kcb.Service.Common.RepositoryServiceMapper.ViewModel
{
    /// <summary>
    /// Init class UserPasswordViewModel
    /// </summary>
    public class UserPasswordViewModel
    {
        /// <summary>
        /// Gets or sets UserPasswordId
        /// </summary>
        public long UserPasswordId { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets UserPasswordSalt
        /// </summary>
        public Guid UserPasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets UserPasswordHash
        /// </summary>
        public byte[] UserPasswordHash { get; set; }

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
        /// Gets or sets User
        /// </summary>
        public virtual UserViewModel User { get; set; }
    }
}
