using System;
using System.Collections.Generic;
using System.Text;

namespace Kcb.Service.Common.RepositoryServiceMapper.Helper
{
    /// <summary>
    /// Init class JwtSettings
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Gets or sets Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets Issuer
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets Audience
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets Subject
        /// </summary>
        public string Subject { get; set; }
    }
}
