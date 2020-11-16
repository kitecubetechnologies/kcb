using System;
using System.Collections.Generic;
using System.Text;

namespace Kcb.Service.Common.Domain.Entities
{
    /// <summary>
    /// Init class AuditEntity
    /// </summary>
    public class AuditEntity
    {
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
    }
}
