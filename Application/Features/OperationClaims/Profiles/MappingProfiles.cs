using Application.Features.OperationClaims.Dtos;
using AutoMapper;
using Core.Domain;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();

        }
    }
}
