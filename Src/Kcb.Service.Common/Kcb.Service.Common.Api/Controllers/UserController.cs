using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kcb.Service.Common.Domain.Entities;
using Kcb.Service.Common.Domain.RequestEntities.RequestModel;
using Kcb.Service.Common.RepositoryPersistence.Infrastructure;
using Kcb.Service.Common.RepositoryServiceMapper.Infrastructure;
using Kcb.Service.Common.RepositoryServiceMapper.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kcb.Service.Common.Api.Controllers
{
    /// <summary>
    /// Init class UserController
    /// </summary>
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        /// <summary>
        /// _userRepository variable
        /// </summary>
        private readonly IMappedUserRepository _mappedUserRepositoryService;

        /// <summary>
        /// UserController constructor
        /// </summary>
        /// <param name="mappedUserRepositoryService">mappedUserRepositoryService</param>
        public UserController(IMappedUserRepository mappedUserRepositoryService)
        {
            _mappedUserRepositoryService = mappedUserRepositoryService;
        }

        /// <summary>
        /// Get All users method
        /// </summary>
        /// <returns></returns>
        // GET: api/<UserController>
        [HttpGet]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mappedUserRepositoryService.Get());
        }

        /// <summary>
        /// Get by id user method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _mappedUserRepositoryService.Get(id));
        }

        /// <summary>
        /// Save user method
        /// </summary>
        /// <param name="userViewModel">userViewModel</param>
        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] UserViewModel userViewModel)
        {
            _mappedUserRepositoryService.Add(userViewModel);

            return RedirectToAction("Get", "User");
        }

        /// <summary>
        /// Update user method
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="userViewModel">userViewModel</param>
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        public IActionResult Put(long id, [FromBody] UserViewModel userViewModel)
        {
            userViewModel.UserId = id;
            _mappedUserRepositoryService.Update(userViewModel);

            return RedirectToAction("Get", "User");
        }

        /// <summary>
        /// Delete user method
        /// </summary>
        /// <param name="id">id</param>
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long id)
        {
            var userViewModel =  await _mappedUserRepositoryService.Get(id);
            _mappedUserRepositoryService.Delete(userViewModel);

            return RedirectToAction("Get", "User");
        }


        /// <summary>
        /// Register user method
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="userViewModel">userViewModel</param>
        // POST api/<UserController>
        [Route("register/{id}")]
        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
        public IActionResult Register(long id, [FromBody] UserRequestModel userViewModel)
        {
            userViewModel.UserId = id;
            _mappedUserRepositoryService.AddOrUpdateUsingProcedure(userViewModel);

            return RedirectToAction("Get", "User");
        }
    }
}
