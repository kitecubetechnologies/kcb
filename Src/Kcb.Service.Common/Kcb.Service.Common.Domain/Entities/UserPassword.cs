using System;
using System.Collections.Generic;
using System.Text;

namespace Kcb.Service.Common.Domain.Entities
{
    /// <summary>
    /// Init UserPassword
    /// </summary>
    public partial class UserPassword : AuditEntity
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
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
    }
}