using AutoMapper;
using Kcb.Service.Common.Domain.Entities;
using Kcb.Service.Common.RepositoryService.Infrastructure;
using Kcb.Service.Common.RepositoryServiceMapper.Helper;
using Kcb.Service.Common.RepositoryServiceMapper.Infrastructure;
using Kcb.Service.Common.RepositoryServiceMapper.ViewModel;
using Kcb.Service.Common.RepositoryServiceMapper.ViewModel.Authenticate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Kcb.Service.Common.Domain.RequestEntities.RequestModel;

namespace Kcb.Service.Common.RepositoryServiceMapper.Repositories
{
    /// <summary>
    /// Init class MappedUserRepository
    /// </summary>
    public class MappedUserRepository : IMappedUserRepository
    {
        /// <summary>
        /// Declare variable _userRepositoryService
        /// </summary>
        private readonly IUserRepository _userRepositoryService;

        /// <summary>
        /// Declare variable _appSettings
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Declare variable _jwtSettings
        /// </summary>
        private readonly JwtSettings _jwtSettings;

        /// <summary>
        /// Declare variable _mapper
        /// </summary>
        private IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepositoryService"></param>
        /// <param name="mapper"></param>
        public MappedUserRepository(IUserRepository userRepositoryService, IMapper mapper, IOptions<AppSettings> appSettings,  IOptions<JwtSettings> jwtSettings)
        {
            _userRepositoryService = userRepositoryService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Authenticate method
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>AuthenticateResponseViewModel</returns>
       public async Task<AuthenticateResponseViewModel> Authenticate(AuthenticateRequestViewModel model)
       {
            User userResponse = await _userRepositoryService.Authenticate(model.Username.ToLower(), model.Password);
            UserViewModel mappedUser = _mapper.Map<UserViewModel>(userResponse);

            // return null if user not found
            if (mappedUser == null) return null;

            AuthenticateResponseViewModel authenticateResponse = new AuthenticateResponseViewModel(mappedUser, string.Empty);

            // authentication successful so generate jwt token
            string token = GenerateJwtToken(authenticateResponse);

            return new AuthenticateResponseViewModel(mappedUser, token);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public async Task<IList<UserViewModel>> Get()
        {
            var userList = await _userRepositoryService.Get();
            var mappedUserList = _mapper.Map<List<UserViewModel>>(userList);
            return mappedUserList;
        }

        /// <summary>
        /// Get by id method
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>UserViewModel</returns>
        public async Task<UserViewModel> Get(long id)
        {
            var user = await _userRepositoryService.Get(id);
            var mappedUser = _mapper.Map<UserViewModel>(user);
            return mappedUser;
        }

        /// <summary>
        /// Add method
        /// </summary>
        /// <param name="userViewModel">userViewModel</param>
        public void Add(UserViewModel userViewModel)
        {
            var mappedUser = _mapper.Map<UserViewModel>(userViewModel);
            var reverseMappedUser = _mapper.Map<User>(mappedUser);
            _userRepositoryService.Add(reverseMappedUser);
            _userRepositoryService.Save();
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="userViewModel">userViewModel</param>
        public void Update(UserViewModel userViewModel)
        {
            var reverseMappedUser = _mapper.Map<User>(userViewModel);
            _userRepositoryService.Update(reverseMappedUser);
            _userRepositoryService.Save();
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="userViewModel">userViewModel</param>
        public void Delete(UserViewModel userViewModel)
        {
            var reverseMappedUser = _mapper.Map<User>(userViewModel);
            _userRepositoryService.Delete(reverseMappedUser);
            _userRepositoryService.Save();
        }

        /// <summary>
        /// Save method
        /// </summary>
        public void Save()
        {
            _userRepositoryService.Save();
        }

        /// <summary>
        /// GenerateJwtToken method
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>string</returns>
        private string GenerateJwtToken(AuthenticateResponseViewModel user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _jwtSettings.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("UserName", user.UserName),
                    new Claim("Email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);


            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// AddOrUpdateUsingProcedure method
        /// </summary>
        /// <param name="entity">entity</param>
        public void AddOrUpdateUsingProcedure(UserRequestModel entity)
        {
            _userRepositoryService.AddOrUpdateUsingProcedure(entity);
        }
    }
}
