using Application.Features.Users.Dtos;
using AutoMapper;
using Core.Domain;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            //.ForMember(x => x.OperationClaims, opt => opt.MapFrom(x => x.UserOperationClaims.Select(x => x.OperationClaim))).ReverseMap();

           

        }
    }
}
