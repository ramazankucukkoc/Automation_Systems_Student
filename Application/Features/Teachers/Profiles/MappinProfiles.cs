using Application.Features.Teachers.Command.CreateCommand;
using Application.Features.Teachers.Command.UpdateCommand;
using Application.Features.Teachers.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Teachers.Profiles
{
    public class MappinProfiles : Profile
    {
        public MappinProfiles()
        {
            CreateMap<DeleteTeacherDto, Teacher>().ReverseMap();
            CreateMap<UpdateTeacherCommand, Teacher>().ReverseMap();
            CreateMap<CreateTeacherDto, Teacher>().ReverseMap();
            CreateMap<CreateTeacherCommand, Teacher>().ReverseMap();
            CreateMap<UpdateTeacherDto, Teacher>().ReverseMap();
            //Queries
            CreateMap<ListTeacherDto, Teacher>().ReverseMap();

        }
    }
}
