using Kcb.Service.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kcb.Service.Common.RepositoryServiceMapper.ViewModel.Authenticate
{
    /// <summary>
    /// Init class AuthenticateResponseViewModel
    /// </summary>
    public class AuthenticateResponseViewModel
    {        
        /// <summary>
        /// Parameterized instance constuctor
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="token">token</param>
        public AuthenticateResponseViewModel(UserViewModel user, string token)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.EmailAddress;
            Token = token;
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
        /// Gets or sets LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public string Token { get; set; }        
    }
}
