using AutoMapper;
using ShopClothesBackend.Features.User.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClothesBackend.Features.User
{
    public class UserMappingProfiler : Profile
    {
        public UserMappingProfiler()
        {
            CreateMap<Command.CreateUser.CreateUserModel, Domain.Domain.User>()
                .ForMember(des => des.Password, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Password)));
            CreateMap<Domain.Domain.User, Login.ResponseLogin>();
        }
    }
}
