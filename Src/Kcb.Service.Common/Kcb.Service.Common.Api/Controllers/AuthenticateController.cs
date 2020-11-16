using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kcb.Service.Common.Domain.RequestEntities.RequestModel;
using Kcb.Service.Common.RepositoryServiceMapper.Infrastructure;
using Kcb.Service.Common.RepositoryServiceMapper.ViewModel.Authenticate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kcb.Service.Common.Api.Controllers
{
    /// <summary>
    /// Init class AuthenticateController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        /// <summary>
        /// _userRepository variable
        /// </summary>
        private readonly IMappedUserRepository _mappedUserRepositoryService;

        /// <summary>
        /// UserController constructor
        /// </summary>
        /// <param name="mappedUserRepositoryService">mappedUserRepositoryService</param>
        public AuthenticateController(IMappedUserRepository mappedUserRepositoryService)
        {
            _mappedUserRepositoryService = mappedUserRepositoryService;
        }

        /// <summary>
        /// Authenticate method
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>IActionResult</returns>
        [AllowAnonymous]
        [HttpPost("signin")]
        [ProducesResponseType(typeof(AuthenticateResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenticateResponseViewModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequestViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (ModelState.IsValid)
            { 
                AuthenticateResponseViewModel response = await _mappedUserRepositoryService.Authenticate(model);

                if (response == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(response);
            }

            return BadRequest(new { message = "Username or password is incorrect" });
        }


        /// <summary>
        /// Register user method
        /// </summary>
        /// <param name="userViewModel">userViewModel</param>
        // POST api/<UserController>
        [Route("registerAnonymous")]
        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] UserRequestModel userViewModel)
        {
            _mappedUserRepositoryService.AddOrUpdateUsingProcedure(userViewModel);

            return Ok(new { message = "User registered successfully" });
        }
    }
}
