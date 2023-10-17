using Application.Features.Students.Command.CreateCommand;
using Application.Features.Students.Command.DeleteCommand;
using Application.Features.Students.Command.UpdateCommand;
using Application.Features.Students.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Students.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateStudentDto, Student>().ReverseMap();
            CreateMap<CreateStudentCommand, Student>().ReverseMap();

            CreateMap<DeleteStudentDto, Student>().ReverseMap();
            CreateMap<DeleteStudentCommand, Student>().ReverseMap();

            CreateMap<UpdateStudentDto, Student>().ReverseMap();
            CreateMap<UpdateCommandStudent, Student>().ReverseMap();

            //Queries
            CreateMap<GetListStudentDto, Student>().ReverseMap();


        }

    }
}
