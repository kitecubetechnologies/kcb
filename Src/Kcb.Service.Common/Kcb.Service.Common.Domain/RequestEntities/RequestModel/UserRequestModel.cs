using System;
using System.Collections.Generic;
using System.Text;

namespace Kcb.Service.Common.Domain.RequestEntities.RequestModel
{
    /// <summary>
    /// Init class UserRequestModel
    /// </summary>
    public class UserRequestModel
    {
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
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or sets LoggedInUserId
        /// </summary>
        public long LoggedInUserId { get; set; }
    }
}
