using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kcb.Service.Common.RepositoryServiceMapper.ViewModel.Authenticate
{
    /// <summary>
    /// Init class AuthenticateRequestViewModel
    /// </summary>
    public class AuthenticateRequestViewModel
    {
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
