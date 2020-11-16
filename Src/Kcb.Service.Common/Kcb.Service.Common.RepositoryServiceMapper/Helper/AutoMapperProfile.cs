using AutoMapper;
using Kcb.Service.Common.RepositoryServiceMapper.ViewModel;
using Kcb.Service.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kcb.Service.Common.RepositoryServiceMapper.ViewModel.Authenticate;

namespace Kcb.Service.Common.RepositoryServiceMapper.Helper
{
    /// <summary>
    /// Init class AutoMapperProfile
    /// </summary>
    public class AutoMapperProfile:Profile
    {
        /// <summary>
        /// Costructor
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>().ReverseMap();

            //CreateMap<AuthenticateResponseViewModel, User>()
            //    .ReverseMap()
            //    .ConstructUsing(foo => new AuthenticateResponseViewModel());
            //    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            //    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //    .ForMember(dest => dest.Token, opt => opt.Ignore())
            //    .ForAllMembers(src => src.Ignore());
        }
    }
}
